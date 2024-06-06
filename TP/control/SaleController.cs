using Oracle.ManagedDataAccess.Client;
using System.Data;
using TP.control;
using TP.Entitiy;

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
