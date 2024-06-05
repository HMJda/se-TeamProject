using System;
using System.Data;

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
        DateTime ProductExDate;
        int ProductQuantity;
        string ProductManufactuer;
        string ProductBarcode;
        string ProductTmpInfo;
        string ProductCategory;
        int ProductUnitPrice;
    }

}
