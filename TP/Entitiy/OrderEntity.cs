using Oracle.ManagedDataAccess.Client;
using System.Data;
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
