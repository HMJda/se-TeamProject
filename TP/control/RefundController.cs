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
        private DateTime selectedDate;
        private int selectedReceiptNumber;
        private DateTimePicker dateTimePicker;
        private TextBox receiptNumberTextBox;

        public RefundController(string dbServerInfo, DateTimePicker dateTimePicker, TextBox receiptNumberTextBox)
        {
            this.dateTimePicker = dateTimePicker;
            this.receiptNumberTextBox = receiptNumberTextBox;
            receiptList = new ReceiptList(dbServerInfo);
            selectedDate = GetDate();
            selectedReceiptNumber = GetReceiptNumber();
        }

        private DateTime GetDate()
        {
            DateTime selectedDate = dateTimePicker.Value;
            return selectedDate;
        }

        private int GetReceiptNumber()
        {
            int receiptNumber;
            if (!int.TryParse(receiptNumberTextBox.Text, out receiptNumber))
            {
                MessageBox.Show("잘못된 영수증 번호입니다.");
            }
            if (receiptNumber.ToString().Length > 10)
            {
                MessageBox.Show("잘못된 영수증 번호입니다.");
            }
            return receiptNumber;
        }

        public DataTable GetReceipt()
        {
            string sqltxt;
            if (selectedReceiptNumber == 0)
            {
                sqltxt = $"SELECT * FROM 영수증 WHERE Date = TO_DATE('{selectedDate:yyyy-MM-dd}', 'YYYY-MM-DD')";
            }
            else
            {
                sqltxt = $"SELECT * FROM 영수증 WHERE No = {selectedReceiptNumber} AND Date = TO_DATE('{selectedDate:yyyy-MM-dd}', 'YYYY-MM-DD')";
            }
            return receiptList.GetReceipts();
        }

        public DataTable GetReceiptDetails(string receiptNo)
        {
            return receiptList.GetReceiptDetails(receiptNo);
        }

        public bool ProcessRefund(int receiptNo)
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

        private void UpdateInventory(int receiptNo)
        {
            string sqltxt = $"UPDATE 재고 SET Quantity = Quantity + (SELECT Quantity FROM 영수증상세 WHERE 영수증번호 = {receiptNo}) WHERE ProductId = (SELECT ProductId FROM 영수증상세 WHERE 영수증번호 = {receiptNo})";
            receiptList.SetReceipt(sqltxt);
        }

        private void SaveRefundedReceipt(int receiptNo)
        {
            string sqltxt = $"INSERT INTO RefundedReceipts (ReceiptNo, RefundDate) VALUES ({receiptNo}, CURRENT_TIMESTAMP)";
            receiptList.SetReceipt(sqltxt);
        }
    }
}