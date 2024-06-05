using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP.Entitiy;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

namespace TP
{
    internal class StockController
    {
        private StockEntity StockEntitiy;

        public StockController()
        {
            StockEntitiy = new StockEntity();
        }

        public DataTable GetStock()
        {
            return StockEntitiy.GetStock();
        }
        public void SetStock(string sqltxt)
        {
            StockEntitiy.SetStock(sqltxt);
        }
        public void SetStock(string sqltxt, OracleParameter[] parameters)
        {
            StockEntitiy.SetStock(sqltxt,parameters);
        }
    }
}
