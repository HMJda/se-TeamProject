using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using TP.control;

namespace TP.Entitiy
{
    internal class ProductInfoEntity
    {
        private string DB_Server_Info = "Data Source = localhost;" +
           "User ID = DEU; Password = 1234;";
        private DBController dBcontroller;
        private DataTable productTable;
        private OracleDataReader productReader;
        private string sqltxt = "select * from 제품";

        public ProductInfoEntity()
        {
            dBcontroller = new DBController();
        }

        public DataTable GetProduct()
        {
            productTable = dBcontroller.GetDB(sqltxt);
            return productTable;
        }
        public DataTable GetProduct(string sqltxt)
        {
            productTable = dBcontroller.GetDB(sqltxt);
            return productTable;
        }
        public OracleDataReader ReadProduct()
        {
            OracleConnection conn = new OracleConnection(DB_Server_Info); //db 연결
            conn.Open();
            OracleCommand cmd = new OracleCommand(sqltxt, conn);
            productReader = cmd.ExecuteReader();

            return productReader;
        }
        public bool IsProductCordExists(string cord)
        {
            productReader = ReadProduct();
            while (productReader.Read())
            {
                string db_productCord = productReader["제품번호"].ToString().Trim();

                if (db_productCord == cord)
                {
                    productReader.Close();
                    return true;
                }
            }
            productReader.Close();
            return false;
        }

        public Tuple<string, string, int> GetProductInfo(string cord)
        {
            string productName = string.Empty;
            int productPrice = 0;

            productReader = ReadProduct();
            while (productReader.Read())
            {
                string db_productCord = productReader["제품번호"].ToString().Trim();
                if (db_productCord == cord)
                {
                    productName = productReader["제품명"].ToString().Trim();
                    productPrice = int.Parse(productReader["단가"].ToString().Trim());
                    break;
                }
            }
            productReader.Close();

            return new Tuple<string, string, int>(cord, productName, productPrice);
        }
    }
}
