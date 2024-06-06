using Oracle.ManagedDataAccess.Client;
using System.Data;
using TP.control;

namespace TP.Entitiy
{
    internal class InvenEntity
    {
        private DBController dBcontroller;
        private DataTable stockTable;
        private string sqltxt = "select 제품.제품번호,제품.제품명,제품.카테고리,제품.규격,제품.제조업체,재고.재고량,가격 from 재고,제품 where 재고.제품번호=제품.제품번호";

        public InvenEntity()
        {
            dBcontroller = new DBController();
        }

        public DataTable GetStock()
        {
            stockTable = dBcontroller.GetDB(sqltxt);
            return stockTable;
        }
        public void SetStock(string sqltxt)
        {
            dBcontroller.SetDB(sqltxt);
        }
        public void SetStock(string sqltxt, OracleParameter[] parameters)
        {
            dBcontroller.ExecuteNonQuery(sqltxt, parameters);
        }
    }
}
