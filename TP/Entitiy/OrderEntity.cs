using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using TP.control;

namespace TP.Entity
{
    public class OrderEntity
    {
        private readonly DBController dbController = new DBController();
        private DataTable orderTable;

        public DataTable GetOrders(string sqltxt)
        {
            orderTable = dbController.GetDB(sqltxt);
            return orderTable;
        }

        public void SetOrder(string sqltxt)
        {
            dbController.SetDB(sqltxt);
        }
        public void SetOrder(string sqltxt, OracleParameter[] parameters)
        {
            dbController.ExecuteNonQuery(sqltxt, parameters);
        }
    }
}
