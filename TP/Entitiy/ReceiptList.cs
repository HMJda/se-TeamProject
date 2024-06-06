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
        private DBController dBcontroller;
        private DataTable receiptTable;

        public ReceiptList()
        {
            dBcontroller = new DBController();
        }

        public DataTable GetReceipt(string sqltxt)
        {
            receiptTable = dBcontroller.GetDB(sqltxt);
            return receiptTable;
        }

        public DataTable GetReceiptDetails(string receiptNo)
        {
            // 영수증 상세 정보를 가져오는 쿼리
            string sqltxt = $"SELECT * FROM 영수증상세 WHERE 영수증번호 = '{receiptNo}'";
            Console.WriteLine($"Executing SQL: {sqltxt}"); // SQL 쿼리 출력

            receiptTable = dBcontroller.GetDB(sqltxt);

            if (receiptTable == null)
            {
                Console.WriteLine("No data returned."); // 디버깅 메시지
            }
            else
            {
                Console.WriteLine($"Rows returned: {receiptTable.Rows.Count}"); // 디버깅 메시지
            }

            return receiptTable;
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