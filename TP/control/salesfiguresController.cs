using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP.Entitiy;

namespace TP.control
{
    internal class salesfiguresController
    {
        private DBController dbEntity;

        public salesfiguresController()
        {
            dbEntity = new DBController();
        }

        public DataTable getMargin()
        {
            return dbEntity.GetDB("select * from 재고");
        }
    }
}
