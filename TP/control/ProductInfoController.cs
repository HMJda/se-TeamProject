using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Entitiy;

namespace TP.control
{
    internal class ProductInfoController
    {
        private ProductInfoEntity productInfoEntity = new ProductInfoEntity();

        public DataTable GetProduct()
        {
            return productInfoEntity.GetProduct("select * from 제품");
        }
    }
    
}
