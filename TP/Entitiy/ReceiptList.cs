using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using TP.control;

namespace TP.Entitiy
{
    internal class ReceiptList
    {
        private DBController dbController;
        private DataTable ReceiptTable;
        private string sqltxt = "select * from 영수증";

        public ReceiptList()
        {
            dbController = new DBController();
            ReceiptTable = new DataTable();
        }
        public DataTable GetReceipt()
        {
            ReceiptTable = dbController.GetDB(sqltxt);
            return ReceiptTable;
        }
        public DataTable GetReceipt(string sqltxt)
        {
            ReceiptTable = dbController.GetDB(sqltxt);
            return ReceiptTable;
        }
        public void SetReceipt(string sqltxt)
        {
            dbController.SetDB(sqltxt);
        }
        public void SetReceipt(string sqltxt, OracleParameter[] parameters)
        {
            dbController.ExecuteNonQuery(sqltxt, parameters);
        }
    }
}
