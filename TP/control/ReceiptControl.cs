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
    }
}