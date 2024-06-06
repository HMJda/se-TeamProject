using System.Text;
using System.Threading.Tasks;
using TP.control;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;

namespace TP.Entitiy
{
    internal class ReceiptList
    {
        private string DB_Server_Info;
        private DBController dBcontroller;
        private string sqltxt = "select * from 영수증";
        private string dbServerInfo = "Data Source = localhost; User ID = DEU; Password = 1234;";

        public ReceiptList()
        {
            DB_Server_Info = dbServerInfo;
            dBcontroller = new DBController();
        }

        public DataTable GetReceipt(string sqltxt)
        {
            return dBcontroller.GetDB(sqltxt);
        }

        public DataTable GetReceiptDetails(string receiptNo)
        {
            // 영수증 상세 정보를 가져오는 쿼리 수정
            string sqltxt = $"SELECT * FROM 영수증상세 WHERE 영수증번호 = '{receiptNo}'";
            return dBcontroller.GetDB(sqltxt);
        }

        public void SaveRefundedReceipt(string receiptNo)
        {
            string sqltxt = $"INSERT INTO RefundedReceipts (영수증번호, RefundDate) VALUES ('{receiptNo}', CURRENT_TIMESTAMP)";
            dBcontroller.SetDB(sqltxt);
        }

        public void SetReceipt(string sqltxt)
        {
            dBcontroller.SetDB(sqltxt);
        }

        public void SetReceipt(string sqltxt, OracleParameter[] parameters)
        {
            dBcontroller.ExecuteNonQuery(sqltxt, parameters);
        }
    }
}