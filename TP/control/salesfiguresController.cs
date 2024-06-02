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
        public DataTable salesCalc(int type,string date)
        {
            string sqltxt ="";
            if (type == 1)
            { //일일판매실적
                sqltxt = string.Format("SELECT * from 대분류별판매실적  where  TO_CHAR(거래시간, 'yyyy-MM-dd') = '{0}'", date);
                return dBController.GetDB(sqltxt);
            }
            else if(type == 2)
            {
                //월별판매실적
                sqltxt = string.Format("SELECT * from 대분류별판매실적  where  TO_CHAR(거래시간, 'yyyy-MM') = '{0}'", date);
                return dBController.GetDB(sqltxt);
            }
            else if(type==3)
            {
                //대분류별판매실적 
                sqltxt = string.Format("SELECT * from 대분류별판매실적  where  TO_CHAR(거래시간, 'yyyy-MM') = '{0}'", date);
                return dBController.GetDB(sqltxt);
            }
            else
            {
                return null;
            }
        }
    }
}
