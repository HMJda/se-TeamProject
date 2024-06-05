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
                sqltxt = $"SELECT * FROM 영수증 WHERE Date = TO_DATE('{date:yyyy-MM-dd}', 'YYYY-MM-DD')";
            }
            else
            {
                sqltxt = $"SELECT * FROM 영수증 WHERE No = {receiptNumber} AND Date = TO_DATE('{date:yyyy-MM-dd}', 'YYYY-MM-DD')";
            }
            return receiptList.GetReceipt(sqltxt);
        }

        public DataTable GetReceiptDetails(int receiptNo)
        {
            string sqltxt = $"SELECT * FROM ReceiptDetails WHERE ReceiptNo = {receiptNo}";
            return receiptList.GetReceipt(sqltxt);
        }

        public bool ProcessRefund(int receiptNo, string paymentMethod)
        {
            // 결제 정보 일치 확인 로직
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
            string sqltxt = $"UPDATE Inventory SET Quantity = Quantity + (SELECT Quantity FROM ReceiptDetails WHERE ReceiptNo = {receiptNo}) WHERE ProductId = (SELECT ProductId FROM ReceiptDetails WHERE ReceiptNo = {receiptNo})";
            receiptList.SetReceipt(sqltxt);
        }

        private void UpdateReceiptList(int receiptNo)
        {
            string sqltxt = $"UPDATE 영수증 SET IsRefunded = 1 WHERE No = {receiptNo}";
            receiptList.SetReceipt(sqltxt);
        }
    }
}