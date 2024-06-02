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
    internal class StockEntity
    {
        private DBController dBcontroller;
        private DataTable stockTable;
        private string sqltxt = "select * from 재고";

        public StockEntity()
        {
            dBcontroller = new DBController();
        }

        public DataTable GetStock()
        {
            stockTable = dBcontroller.GetDB(sqltxt);
            return stockTable;
        }
        public void SetStock(string sqltxt)
        {
            dBcontroller.SetDB(sqltxt);
        }
        public void SetStock(string sqltxt, OracleParameter[] parameters)
        {
            dBcontroller.ExecuteNonQuery(sqltxt,parameters);
        }
    }
}
