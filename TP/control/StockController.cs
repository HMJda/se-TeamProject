using Oracle.ManagedDataAccess.Client;
using System.Data;
using TP.Entitiy;

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
            StockEntitiy.SetStock(sqltxt, parameters);
        }
    }
}
