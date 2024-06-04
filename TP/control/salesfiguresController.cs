using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using TP.Entitiy;

namespace TP.control
{
    internal class salesfiguresController
    {
        private ReceiptList receiptList;

        public salesfiguresController()
        {
            receiptList = new ReceiptList();
        }

        public DataTable getMargin(int year)
        {
            string sqltxt = $@"
            SELECT 
                EXTRACT(MONTH FROM r.거래시간) AS 월,
                SUM(rs.수량 * rs.상품가격) AS 총판매액,
                SUM(rs.수량 * p.단가) AS 총원가
            FROM 
                영수증 r
            JOIN 
                영수증상세 rs ON r.영수증번호 = rs.영수증번호
            JOIN 
                제품 p ON rs.제품번호 = p.제품번호
            WHERE 
                EXTRACT(YEAR FROM r.거래시간) = {year}
            GROUP BY 
                EXTRACT(MONTH FROM r.거래시간)";

            return receiptList.GetReceipt(sqltxt);
        }
        public DataTable salesCalc(int type,string date)
        {
            string sqltxt;
            if (type == 1)
            { //일일판매실적
                sqltxt = string.Format("SELECT " +
                    "TO_CHAR(거래시간, 'HH24') || '시' AS 시간, " +
                    "SUM(CASE WHEN 거래형태 = '결제' THEN 총가격 ELSE 0 END) AS 결제금액, " +
                    "SUM(CASE WHEN 거래형태 = '반품' THEN 총가격 ELSE 0 END) AS 반품금액, " +
                    "COUNT(DISTINCT 영수증.영수증번호) AS 객수, " +
                    "SUM(CASE WHEN 거래형태 = '결제' THEN 총가격 ELSE 0 END) + " +
                    "SUM(CASE WHEN 거래형태 = '반품' THEN 총가격 ELSE 0 END) AS 판매금액 FROM 영수증 " +
                    "JOIN 영수증상세 ON 영수증.영수증번호 = 영수증상세.영수증번호 " +
                    "WHERE TRUNC(거래시간) = TO_DATE('{0}', 'YYYY-MM-DD') " +
                    "GROUP BY TO_CHAR(거래시간, 'YYYY-MM-DD HH24'), " +
                    "TO_CHAR(거래시간, 'HH24') || '시' " +
                    "ORDER BY TO_CHAR(거래시간, 'YYYY-MM-DD HH24')", date);
                return receiptList.GetReceipt(sqltxt);
            }
            else if(type == 2)
            {
                //월별판매실적
                sqltxt = string.Format("SELECT " +
                    "TO_CHAR(거래시간, 'YYYY-MM-DD') AS 거래일자, " +
                    "SUM(CASE WHEN 거래형태 = '결제' THEN 총가격 ELSE 0 END) AS 결제금액, " +
                    "SUM(CASE WHEN 거래형태 = '반품' THEN 총가격 ELSE 0 END) AS 반품금액, " +
                    "COUNT(DISTINCT 영수증.영수증번호) AS 객수, " +
                    "SUM(CASE WHEN 거래형태 = '결제' THEN 총가격 ELSE 0 END) + " +
                    "SUM(CASE WHEN 거래형태 = '반품' THEN 총가격 ELSE 0 END) AS 판매금액 " +
                    "FROM 영수증 JOIN 영수증상세 ON 영수증.영수증번호 = 영수증상세.영수증번호 " +
                    "WHERE TO_CHAR(거래시간, 'YYYY-MM') = '{0}' " +
                    "GROUP BY TO_CHAR(거래시간, 'YYYY-MM-DD')," +
                    "TO_CHAR(거래시간, 'DD') || '일' ORDER BY 거래일자", date);
                return receiptList.GetReceipt(sqltxt);
            }
            else if(type==3)
            {
                //대분류별판매실적 
                sqltxt = string.Format("SELECT * from 대분류별판매실적  where  TO_CHAR(거래시간, 'yyyy-MM') = '{0}'", date);
                return receiptList.GetReceipt(sqltxt);
            }
            else
            {
                return null;
            }
        }
    }
}