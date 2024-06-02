using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.control;

namespace TP.Entitiy
{
    internal class ProductInfoEntity
    {
        private DBController dBcontroller;
        private DataTable productTable;
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
    }
}
