using System.Data;
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
