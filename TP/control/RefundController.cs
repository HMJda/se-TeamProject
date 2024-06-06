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

        public RefundController(string dbServerInfo, DateTimePicker dateTimePicker, TextBox receiptNumberTextBox)
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

        public DataTable GetReceipt()
        {
            DateTime selectedDate = GetDate();
            string receiptNumber = GetReceiptNumber();
            if (receiptNumber != null)
            {
                return receiptList.GetReceipt(selectedDate, receiptNumber);
            }
            else
            {
                return null;
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
            string sqltxt = $"UPDATE 재고 SET Quantity = Quantity + (SELECT 수량 FROM 영수증상세 WHERE 영수증번호 = '{receiptNo}') WHERE ProductId = (SELECT ProductId FROM 영수증상세 WHERE 영수증번호 = '{receiptNo}')";
            receiptList.SetReceipt(sqltxt);
        }

        private void SaveRefundedReceipt(string receiptNo)
        {
            string sqltxt = $"INSERT INTO RefundedReceipts (ReceiptNo, RefundDate) VALUES ('{receiptNo}', CURRENT_TIMESTAMP)";
            receiptList.SetReceipt(sqltxt);
        }
    }
}