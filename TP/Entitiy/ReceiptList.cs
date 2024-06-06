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
        private DataTable ReceiptTable;
        private string sqltxt = "select * from 영수증";

        public ReceiptList(string dbServerInfo)
        {
            DB_Server_Info = dbServerInfo;
            dBcontroller = new DBController();
        }

        public ReceiptList()
        {
            dBcontroller = new DBController();
        }

        public OracleDataReader ReadReceipts()
        {
            using (OracleConnection conn = new OracleConnection(DB_Server_Info))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(sqltxt, conn);
                return cmd.ExecuteReader();
            }
        }

        public DataTable GetReceipt()
        {
            ReceiptTable = dBcontroller.GetDB(sqltxt);
            return ReceiptTable;
        }

        public DataTable GetReceipts()
        {
            ReceiptTable = dBcontroller.GetDB("select * from 영수증");
            return ReceiptTable;
        }

        public DataTable GetReceipt(string sqltxt)
        {
            return dBcontroller.GetDB(sqltxt);
        }

        public DataTable GetReceipt(DateTime selectedDate, string receiptNumber) // 수정된 메서드
        {
            string sqltxt = $"SELECT * FROM 영수증 WHERE 거래일자 = TO_DATE('{selectedDate:yyyy-MM-dd}', 'YYYY-MM-DD') AND 영수증번호 = '{receiptNumber}'";
            return dBcontroller.GetDB(sqltxt);
        }

        public DataTable GetReceiptDetails(string receiptNo)
        {
            string sqltxt = $"SELECT * FROM 영수증상세 WHERE 영수증번호 = '{receiptNo}'";
            return dBcontroller.GetDB(sqltxt);
        }

        public bool IsReceiptExists(string receiptNumber) // 수정된 메서드
        {
            using (OracleDataReader receiptReader = ReadReceipts())
            {
                while (receiptReader.Read())
                {
                    string db_receiptNumber = receiptReader["영수증번호"].ToString();
                    if (db_receiptNumber == receiptNumber)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public Dictionary<string, string> GetReceiptInfo(string receiptNumber)
        {
            using (OracleDataReader receiptReader = ReadReceipts())
            {
                while (receiptReader.Read())
                {
                    string db_receiptNumber = receiptReader["영수증번호"].ToString();
                    if (db_receiptNumber == receiptNumber)
                    {
                        string transactionTime = receiptReader["거래시간"].ToString();
                        string transactionType = receiptReader["거래형태"].ToString();
                        string totalPrice = receiptReader["총가격"].ToString();

                        return new Dictionary<string, string>
                        {
                            { "영수증번호", receiptNumber },
                            { "거래시간", transactionTime },
                            { "거래형태", transactionType },
                            { "총가격", totalPrice }
                        };
                    }
                }
                return null;
            }
        }

        public void SaveRefundedReceipt(string receiptNo)
        {
            string sqltxt = $"INSERT INTO RefundedReceipts (ReceiptNo, RefundDate) VALUES ('{receiptNo}', CURRENT_TIMESTAMP)";
            DBController dBController = new DBController();
            dBController.SetDB(sqltxt);
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