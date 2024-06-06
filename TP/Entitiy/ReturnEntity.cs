using Oracle.ManagedDataAccess.Client;
using System.Data;
using TP.control;

namespace TP.Entitiy
{
    internal class ReturnEntity
    {
        private readonly DBController dbController = new DBController();
        private DataTable returnTable;

        public DataTable GetReturn(string sqltxt)
        {
            returnTable = dbController.GetDB(sqltxt);
            return returnTable;
        }

        public void SetReturn(string sqltxt)
        {
            dbController.SetDB(sqltxt);
        }
        public void SetReturn(string sqltxt, OracleParameter[] parameters)
        {
            dbController.ExecuteNonQuery(sqltxt, parameters);
        }
    }
}
