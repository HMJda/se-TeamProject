namespace TP
{
    public class LoginController
    {
        UserEntity userEntity;
        public LoginController()
        {
            userEntity = new UserEntity();
        }
        private bool loginsucces = false; //로그인 성공 여부 
        public bool checkUser(string id, string pw)
        {
            if (userEntity.IsUserExists(id, pw))
            {
                loginsucces = true;
            }
            else
            {
                loginsucces = false;
            }
            return loginsucces;
        }
        public string GetUserDetail(string id, string key)
        {
            var userInfo = userEntity.GetUserInfo(id);
            if (userInfo != null && userInfo.ContainsKey(key))
            {
                return userInfo[key];
            }
            return null; // 해당 키가 없거나 사용자가 없는 경우 null 반환
        }
    }
}
