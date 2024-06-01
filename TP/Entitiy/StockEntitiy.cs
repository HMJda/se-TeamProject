using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.control;

namespace TP.Entitiy
{
    internal class StockEntitiy
    {
        private DBController dBcontroller;
        private DataTable stock;
        private string sqltxt = "select * from 재고";

        public StockEntitiy()
        {
            dBcontroller = new DBController();
        }

        public DataTable GetStock()
        {
            stock = dBcontroller.GetDB(sqltxt);
            return stock;
        }
        public DataTable GetStock(string sqltxt)
        {
            stock = dBcontroller.GetDB(sqltxt);
            return stock;
        }
    }
}
