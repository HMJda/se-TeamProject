﻿using System;
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
        private DBEntity dbEntity;

        public StockController()
        {
            dbEntity = new DBEntity();
        }

        public DataTable GetDB()
        {
            return dbEntity.GetDB("select * from 재고");
        }
    }
}
