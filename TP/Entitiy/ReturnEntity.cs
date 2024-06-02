using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.control;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

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
