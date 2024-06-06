using Oracle.ManagedDataAccess.Client;
using System.Data;
using TP.Entitiy;

namespace TP
{
    internal class InquiryInvenController
    {
        private InvenEntity invenEntity;

        public InquiryInvenController()
        {
            invenEntity = new InvenEntity();
        }

        public DataTable GetStock()
        {
            return invenEntity.GetStock();
        }
        public void SetStock(string sqltxt)
        {
            invenEntity.SetStock(sqltxt);
        }
        public void SetStock(string sqltxt, OracleParameter[] parameters)
        {
            invenEntity.SetStock(sqltxt, parameters);
        }
    }
}
