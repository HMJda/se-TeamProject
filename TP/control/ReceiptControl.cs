using System;
using System.Data;
using TP.Entitiy;

namespace TP.control
{
    internal class ReceiptControl
    {
        private ReceiptList receiptList;

        public ReceiptControl()
        {
            receiptList = new ReceiptList();
        }

        public DataTable GetReceipt(DateTime date, int receiptNumber)
        {
            string sqltxt;
            if (receiptNumber == 0)
            {
                sqltxt = $"SELECT * FROM 영수증 WHERE 거래시간 = TO_DATE('{date:yyyy-MM-dd}', 'YYYY-MM-DD')";
            }
            else
            {
                sqltxt = $"SELECT * FROM 영수증 WHERE 영수증번호 = {receiptNumber} AND 거래시간 = TO_DATE('{date:yyyy-MM-dd}', 'YYYY-MM-DD')";
            }
            return receiptList.GetReceipt(sqltxt);
        }

        public DataTable GetReceiptDetails(int receiptNo)
        {
            string sqltxt = $"SELECT * FROM 영수증상세 WHERE 영수증번호 = {receiptNo}";
            return receiptList.GetReceipt(sqltxt);
        }

        public bool ProcessRefund(int receiptNo, string paymentMethod)
        {
            string sqltxt = $"SELECT PaymentMethod FROM 영수증 WHERE No = {receiptNo}";
            DataTable dt = receiptList.GetReceipt(sqltxt);
            if (dt.Rows.Count > 0 && dt.Rows[0]["PaymentMethod"].ToString() == paymentMethod)
            {
                UpdateInventory(receiptNo);
                UpdateReceiptList(receiptNo);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdateInventory(int receiptNo)
        {
            string sqltxt = $"UPDATE Inventory SET Quantity = Quantity + (SELECT Quantity FROM 영수증상세 WHERE 영수증번호 = {receiptNo}) WHERE ProductId = (SELECT ProductId FROM 영수증상세 WHERE 영수증번호 = {receiptNo})";
            receiptList.SetReceipt(sqltxt);
        }

        private void UpdateReceiptList(int receiptNo)
        {
            string sqltxt = $"UPDATE 영수증 SET IsRefunded = 1 WHERE No = {receiptNo}";
            receiptList.SetReceipt(sqltxt);
        }
    }
}