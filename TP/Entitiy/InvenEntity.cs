using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TP.control;

namespace TP.Entitiy
{
    internal class InvenEntity
    {
        public DataTable getDB()
        {
            DataTable dataTable = new DataTable();
            return dataTable;
        }
        int ProductCode;
        string ProductName;
        DateTime ProductExDate ;
        int ProductQuantity;
        string ProductManufactuer;
        string ProductBarcode;
        string ProductTmpInfo;
        string ProductCategory;
        int ProductUnitPrice;
    }

}
