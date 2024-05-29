﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace TP.Entitiy
{
    internal class DBEntity
    {
        private string DB_Server_Info = "Data Source = localhost; User ID = system; Password = 1234;";

        public DataTable GetStocks(string sqltxt)
        {
            OracleConnection conn = new OracleConnection(DB_Server_Info);
            conn.Open();
            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = new OracleCommand(sqltxt, conn);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adapt.Fill(ds);
            dt.Reset();
            dt = ds.Tables[0];
            conn.Close();
            return dt;
        }
        public void SetStocks(string sqltxt)
        {
            
        }
    }
}
