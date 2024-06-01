using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TP.Entitiy;

namespace TP
{
    public class StockController
    {
        private StockEntitiy StockEntitiy;

        public StockController()
        {
            StockEntitiy = new StockEntitiy();
        }

        public DataTable GetStock()
        {
            return StockEntitiy.GetStock("select * from 재고");
        }
    }
}
