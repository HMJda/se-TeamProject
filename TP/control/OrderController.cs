using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using TP.Entity;
using System.Data;

namespace TP.control
{
    public class OrderController
    {
        private readonly OrderEntity orderEntity = new OrderEntity();

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
    }
}