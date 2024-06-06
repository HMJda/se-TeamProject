using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using TP.Entitiy;

namespace TP.control
{
    internal class RefundController
    {
        private ReceiptList receiptList;
        private DateTimePicker dateTimePicker;
        private TextBox receiptNumberTextBox;
        private string dbServerInfo = "Data Source = localhost; User ID = DEU; Password = 1234;";

        public RefundController(DateTimePicker dateTimePicker, TextBox receiptNumberTextBox)
        {
            this.dateTimePicker = dateTimePicker;
            this.receiptNumberTextBox = receiptNumberTextBox;
            receiptList = new ReceiptList(dbServerInfo);
        }

        private DateTime GetDate()
        {
            return dateTimePicker.Value;
        }

        private string GetReceiptNumber()
        {
            string receiptNumber = receiptNumberTextBox.Text;
            if (receiptNumber.Length <= 10)
            {
                return receiptNumber;
            }
            MessageBox.Show("잘못된 영수증 번호입니다.");
            return null;
        }

        public DataTable GetReceipt(DateTime selectedDate, string receiptNumber = null)
        {
            if (string.IsNullOrEmpty(receiptNumber))
            {
                string sqltxt = $"SELECT * FROM 영수증 WHERE TO_CHAR(거래시간, 'YYYY-MM-DD') ='{selectedDate.ToString("yyyy-MM-dd")}'";
                return receiptList.GetReceipt(sqltxt);
            }
            else
            {
                string sqltxt = $"SELECT * FROM 영수증 WHERE TO_CHAR(거래시간, 'YYYY-MM-DD') ='{selectedDate.ToString("yyyy-MM-dd")}' AND 영수증번호 = '{receiptNumber}'";
                return receiptList.GetReceipt(sqltxt);
            }
        }

        public DataTable GetReceiptDetails(string receiptNo)
        {
            return receiptList.GetReceiptDetails(receiptNo);
        }

        public bool ProcessRefund(string receiptNo)
        {
            try
            {
                UpdateInventory(receiptNo);
                SaveRefundedReceipt(receiptNo);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"환불 처리 중 오류 발생: {ex.Message}");
                return false;
            }
        }

        private void UpdateInventory(string receiptNo)
        {
            // 재고 업데이트 쿼리 수정
            string sqltxt = $"UPDATE 재고 SET 수량 = 수량 + (SELECT 수량 FROM 영수증상세 WHERE 영수증번호 = '{receiptNo}') WHERE 제품번호 = (SELECT 제품번호 FROM 영수증상세 WHERE 영수증번호 = '{receiptNo}')";
            receiptList.SetReceipt(sqltxt);
        }

        private void SaveRefundedReceipt(string receiptNo)
        {
            string sqltxt = $"INSERT INTO RefundedReceipts (ReceiptNo, RefundDate) VALUES ('{receiptNo}', CURRENT_TIMESTAMP)";
            receiptList.SetReceipt(sqltxt);
        }
    }
}