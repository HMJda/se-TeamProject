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
            receiptList = new ReceiptList();
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
            string sqltxt = $"INSERT INTO RefundedReceipts (영수증번호, RefundDate) VALUES ('{receiptNo}', CURRENT_TIMESTAMP)";
            receiptList.SetReceipt(sqltxt);
        }
    }
}