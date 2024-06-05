using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.control;

namespace TP.Entitiy
{
    internal class ReceiptList
    {
        private DBController dBcontroller;
        private DataTable ReceiptTable;
        private string sqltxt = "select * from 영수증";

        public ReceiptList()
        {
            dBcontroller = new DBController();
        }

        public DataTable GetReceipt()
        {
            ReceiptTable = dBcontroller.GetDB(sqltxt);
            return ReceiptTable;
        }
        public DataTable GetReceipt(string sqltxt)
        {
            ReceiptTable = dBcontroller.GetDB(sqltxt);
            return ReceiptTable;
        }
        public void SetReceipt(string sqltxt)
        {
            dBcontroller.SetDB(sqltxt);
        }
    }
}
