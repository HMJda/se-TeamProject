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
            this.receiptNumberTextBox = receiptNumberTextBox; // 텍스트 상자에 대한 참조 저장
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
            // 사용자가 입력한 영수증 번호를 텍스트 상자에서 가져오는 로직
            int receiptNumber;
            if (!int.TryParse(receiptNumberTextBox.Text, out receiptNumber))
            {
                // 사용자가 올바른 숫자를 입력하지 않은 경우 처리
                MessageBox.Show("잘못된 영수증 번호입니다.");
            }
            // 10자리 이상의 숫자를 입력한 경우 처리
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

        public DataTable GetReceiptDetails(int receiptNo)
        {
            string sqltxt = $"SELECT * FROM ReceiptDetails WHERE ReceiptNo = {receiptNo}";
            return receiptList.GetReceipts();
        }

        public bool ProcessRefund(int receiptNo)
        {
            try
            {
                // 환불 처리 로직
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
            string sqltxt = $"UPDATE 재고 SET Quantity = Quantity + (SELECT Quantity FROM ReceiptDetails WHERE ReceiptNo = {receiptNo}) WHERE ProductId = (SELECT ProductId FROM ReceiptDetails WHERE ReceiptNo = {receiptNo})";
            receiptList.SetReceipt(sqltxt);
        }

        private void SaveRefundedReceipt(int receiptNo)
        {
            string sqltxt = $"INSERT INTO RefundedReceipts (ReceiptNo, RefundDate) VALUES ({receiptNo}, CURRENT_TIMESTAMP)";
            receiptList.SetReceipt(sqltxt);
        }
    }
}