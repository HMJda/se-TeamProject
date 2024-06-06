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

        // 생성자를 통해 DB 연결 정보를 주입받도록 변경
        public ReceiptList(string dbServerInfo)
        {
            DB_Server_Info = dbServerInfo;
        }
        public ReceiptList()
        {
            dBcontroller = new DBController();
        }

        public OracleDataReader ReadReceipts() // 읽기만 하는 용도
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

        public DataTable GetReceipts() // 영수증 정보 모두 받는 용도
        {
            DBController dBController = new DBController();
            return dBController.GetDB("select * from 영수증");
        }

        public bool IsReceiptExists(int receiptNumber)
        {
            using (OracleDataReader receiptReader = ReadReceipts())
            {
                while (receiptReader.Read())
                {
                    int db_receiptNumber = Convert.ToInt32(receiptReader["영수증번호"]);
                    if (db_receiptNumber == receiptNumber)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public Dictionary<string, string> GetReceiptInfo(int receiptNumber)
        {
            using (OracleDataReader receiptReader = ReadReceipts())
            {
                while (receiptReader.Read())
                {
                    int db_receiptNumber = Convert.ToInt32(receiptReader["영수증번호"]);
                    if (db_receiptNumber == receiptNumber)
                    {
                        // 필드 데이터 읽기
                        string transactionTime = receiptReader["거래시간"].ToString();
                        string transactionType = receiptReader["거래형태"].ToString();
                        string totalPrice = receiptReader["총가격"].ToString();

                        // 영수증 정보를 딕셔너리에 저장
                        return new Dictionary<string, string>
                        {
                            { "영수증번호", receiptNumber.ToString() },
                            { "거래시간", transactionTime },
                            { "거래형태", transactionType },
                            { "총가격", totalPrice }
                        };
                    }
                }
                return null; // 매칭되는 영수증이 없을 경우 null 반환
            }
        }

        public void SaveRefundedReceipt(int receiptNo)
        {
            string sqltxt = $"INSERT INTO RefundedReceipts (ReceiptNo, RefundDate) VALUES ({receiptNo}, CURRENT_TIMESTAMP)";
            DBController dBController = new DBController();
            dBController.SetDB(sqltxt);
        }
        public DataTable GetReceipt(string sqltxt)
        {

            ReceiptTable = dBcontroller.GetDB(sqltxt);
            return ReceiptTable;
        }

        public void SetReceipt(string sqltxt)
        {
            using (OracleConnection conn = new OracleConnection(DB_Server_Info))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand(sqltxt, conn);
                cmd.ExecuteNonQuery();
            }
            dBcontroller.SetDB(sqltxt);
        }
    }
}
