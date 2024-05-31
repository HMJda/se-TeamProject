using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace TP
{
    public class UserEntity
    {
        private string DB_Server_Info = "Data Source = localhost;" +
           "User ID = DEU; Password = 1234;";

        public OracleDataReader GetUsers()
        {
            /*CREATE TABLE 회원 (
               ID VARCHAR2(12) PRIMARY KEY,
               PW VARCHAR2(12) NOT NULL,
               Name VARCHAR2(17),
               Address VARCHAR2(50),
               Phone VARCHAR2(13),
               Position VARCHAR2(13)
            );*/
            string sqltxt = "select * from 회원";
            OracleConnection conn = new OracleConnection(DB_Server_Info); //db 연결
            conn.Open();
            OracleCommand cmd = new OracleCommand(sqltxt, conn);
            OracleDataReader reader = cmd.ExecuteReader();

            return reader;
        }
        public bool IsUserExists(string id, string pw)
        {
            OracleDataReader reader = GetUsers();
            while (reader.Read())
            {
                string db_id = reader["ID"].ToString().Trim(); //db상 아이디 비번뒤 공백 삭제
                string db_pw = reader["PW"].ToString().Trim();

                if (db_id == id && db_pw == pw)
                {
                    reader.Close();
                    return true;
                }
            }
            reader.Close();
            return false;
        }
        public Dictionary<string, string> GetUserInfo(string id)
        {
            OracleDataReader reader = GetUsers();
            while (reader.Read())
            {
                string db_id = reader["ID"].ToString().Trim();
                if (db_id == id)
                {
                    // 필드 데이터 읽기
                    string name = reader["Name"] as string;
                    string duty = reader["Position"] as string;
                    string adress = reader["Address"] as string;

                    // 사용자 정보를 딕셔너리에 저장
                    Dictionary<string, string> userInfo = new Dictionary<string, string>
                {
                    { "ID", id },
                    { "Name", name },
                    { "Position", duty },
                    { "Address", adress }
                };

                    reader.Close();
                    return userInfo;
                }
            }
            reader.Close();
            return null; // 매칭되는 회원이 없을 경우 null 반환
        }

    }
}
