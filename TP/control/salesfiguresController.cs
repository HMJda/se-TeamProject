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
        private DBController dBController;

        public salesfiguresController()
        {
            dBController = new DBController();
        }

        public DataTable getMargin()
        {
            return dBController.GetDB("select * from 재고");
        }
    }
}
