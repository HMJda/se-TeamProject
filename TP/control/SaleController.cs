using System;
using System.Data;
using TP;
using TP.control;
using TP.Entitiy;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;

public class SaleController
{
    private ReceiptList receiptList;
    private DBController dbController;
    private DataTable ReceiptTable;
    public SaleController()
    {
        receiptList = new ReceiptList();
    }
    public void SetReceipt(string sqltxt)
    {
        receiptList.SetReceipt(sqltxt);
    }
    public void SetReceipt(string sqltxt, OracleParameter[] parameters)
    {
        receiptList.SetReceipt(sqltxt, parameters);
    }
}
