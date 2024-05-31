using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace TP.Entitiy
{
    internal class DBEntity
    {
        private string DB_Server_Info = "Data Source = localhost; " +
            "User ID = DEU; Password = 1234;"; 

        public DataTable GetStocks(string sqltxt)
        {
            OracleConnection conn = new OracleConnection(DB_Server_Info);
            conn.Open();
            OracleDataAdapter adapt = new OracleDataAdapter();
            adapt.SelectCommand = new OracleCommand(sqltxt, conn);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            adapt.Fill(ds);
            dt.Reset();
            dt = ds.Tables[0];
            conn.Close();
            return dt;
        }
        public void SetStocks(string sqltxt)
        {
            
        }
    }
}
/* ---db 생성문 
ALTER session set "_ORACLE_SCRIPT"=true;
DROP USER DEU CASCADE; -- 기존 사용자 삭제(현재 접속되어 있으면 삭제 안 됨)
	-- CASCADE option : 관련 스키마 개체들도 함께 삭제.  Default는 No Action
CREATE USER DEU IDENTIFIED BY 1234  -- 사용자 ID : DEU, 비밀번호 : 1234
    DEFAULT TABLESPACE USERS
    TEMPORARY TABLESPACE TEMP;
GRANT connect, resource, dba TO DEU; -- 권한 부여

CREATE TABLE 회원 (
    ID VARCHAR2(12) PRIMARY KEY,
    PW VARCHAR2(12) NOT NULL,
    Name VARCHAR2(17) NOT NULL,
    Address VARCHAR2(50) NOT NULL,
    Phone VARCHAR2(13),
    Position VARCHAR2(13) NOT NULL
);

CREATE TABLE 제품 (
    ProductCode INTEGER PRIMARY KEY,
    ProductName VARCHAR2(12) NOT NULL,
    ProductExDate DATE,
    ProductOrderPrice INTEGER NOT NULL,
    ProductManufacturer VARCHAR2(12) NOT NULL, 
    ProductCategory VARCHAR2(12) NOT NULL
);

CREATE TABLE 발주 (
    OrderNumber NUMBER PRIMARY KEY,
    ProductCode NUMBER,
    OrderDate DATE NOT NULL,
    OrderQuantity NUMBER NOT NULL,
    OrderAmount NUMBER NOT NULL,
    OrderPrice NUMBER NOT NULL,
    FOREIGN KEY (ProductCode) REFERENCES 제품(ProductCode)
);

CREATE TABLE 반품 (
    ReturnNumber NUMBER PRIMARY KEY,
    ProductCode NUMBER,
    ReturnQuantity NUMBER NOT NULL,
    ReturnDate DATE NOT NULL,
    FOREIGN KEY (ProductCode) REFERENCES 제품(ProductCode)
);
CREATE TABLE 재고 (
    ProductBarcode VarChar(12) PRIMARY KEY,
    ProductCode Integer,
    ProductQuantity Integer NOT NULL,
    ProductCategory Varchar(12) NOT NULL,
    ProductUnitPrice Integer NOT NULL,
    ProductTmpInfo Varchar(12),
    FOREIGN KEY (ProductCode) REFERENCES 제품(ProductCode)
);
CREATE TABLE 영수증 (
    DealNumber Integer PRIMARY KEY,
    ProductBarcode VarChar(30),
    DealTime DATE NOT NULL, ---왜 VarChar(30)?
    DealType VarChar(30) NOT NULL,
    TotalAmount Integer NOT NULL,
    ProductName VarChar(30) NOT NULL,
    ProductQuantity Integer NOT NULL,
    ProductUnitPrice Integer NOT NULL,
    ProductPrice Integer NOT NULL,
    Category Varchar(12),
    FOREIGN KEY (ProductBarcode) REFERENCES 재고(ProductBarcode)
); */
