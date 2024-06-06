using Oracle.ManagedDataAccess.Client;
using System.Data;
using TP.Entitiy;
using TP.Entity;

namespace TP.control
{
    public class OrderReturnController
    {
        private OrderEntity orderEntity = new OrderEntity();
        private ReturnEntity returnEntity = new ReturnEntity();

        public DataTable GetOrders(string sqltxt)
        {
            return orderEntity.GetOrders(sqltxt);
        }

        public void SetOrder(string sqltxt)
        {
            orderEntity.SetOrder(sqltxt);
        }
        public void SetOrder(string sqltxt, OracleParameter[] parameters)
        {
            orderEntity.SetOrder(sqltxt, parameters);
        }

        public DataTable GetReturn(string sqltxt)
        {
            return returnEntity.GetReturn(sqltxt);
        }

        public void SetReturn(string sqltxt)
        {
            returnEntity.SetReturn(sqltxt);
        }
        public void SetReturn(string sqltxt, OracleParameter[] parameters)
        {
            returnEntity.SetReturn(sqltxt, parameters);
        }
    }
}