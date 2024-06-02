using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using TP.control;

namespace TP
{
    public class UserEntity
    {
        private string DB_Server_Info = "Data Source = localhost;" +
           "User ID = DEU; Password = 1234;";
        private string sqltxt = "select * from 회원";
        private Dictionary<string, string> userInfo;
        private OracleDataReader userReader;
        private DataTable userTable;

        public OracleDataReader ReadUsers() //읽기만 하는 용도 
        {   
            OracleConnection conn = new OracleConnection(DB_Server_Info); //db 연결
            conn.Open();
            OracleCommand cmd = new OracleCommand(sqltxt, conn);
            userReader = cmd.ExecuteReader();

            return userReader;
        }
        public DataTable GetUsers() //유저 정보 모두 받는 용도 
        {
            DBController dBController = new DBController();
            userTable = dBController.GetDB("select * from 회원");
            return userTable;
        }
        public bool IsUserExists(string id, string pw)
        {
            userReader = ReadUsers();
            while (userReader.Read())
            {
                string db_id = userReader["아이디"].ToString().Trim(); //db상 아이디 비번뒤 공백 삭제
                string db_pw = userReader["비번"].ToString().Trim();

                if (db_id == id && db_pw == pw)
                {
                    userReader.Close();
                    return true;
                }
            }
            userReader.Close();
            return false;
        }
        public Dictionary<string, string> GetUserInfo(string id)
        {
            userReader = ReadUsers();
            while (userReader.Read())
            {
                string db_id = userReader["아이디"].ToString().Trim();
                if (db_id == id)
                {
                    // 필드 데이터 읽기
                    string name = userReader["이름"] as string;
                    string duty = userReader["직책"] as string;
                    string adress = userReader["편의점주소"] as string;

                    // 사용자 정보를 딕셔너리에 저장
                    userInfo = new Dictionary<string, string>
                {
                    { "아이디", id },
                    { "이름", name },
                    { "직책", duty },
                    { "편의점주소", adress }
                };

                    userReader.Close();
                    return userInfo;
                }
            }
            userReader.Close();
            return null; // 매칭되는 회원이 없을 경우 null 반환
        }

    }
}
