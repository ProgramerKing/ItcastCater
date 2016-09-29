using ItcastCater.DAL;
using ItcastCater.Models;

namespace ItcastCater.BLL
{
    public class UserInfoService
    {
        UserInfoDal dalUser = new UserInfoDal();
        #region 用户登录 一
        public bool UserLogin(string LoginUserName, string UserPwd)
        {
            return dalUser.IsLoginByLoginName(LoginUserName, UserPwd) > 0;
        }
        #endregion

        #region 用户登录 二
        #region 写法一
        public LoginResult IsLoginByLoginName(string LoginUserName, string UserPwd, out string realName, out int UserID)
        {
            realName = string.Empty;
            UserID = -1;
            //1.调用数据访问层，根据UserID查询基本信息
            UserInfo model = dalUser.GetUserInfoByUserID(LoginUserName);
            //2.根据查询到的信息，判断用户登录结果
            if (model == null)
            {
                return LoginResult.UserIDExists;
            }
            else if (model.UserPwd == UserPwd)
            {
                realName = model.LoginUserName;
                UserID = model.UserID;
                return LoginResult.OK;
            }
            else
            {
                return LoginResult.ErrorPassword;
            }
        }
        #endregion
        #region 写法二
        public bool IsLoginByLoginName(string LoginUserName,string UserPwd,out string msg)
        {
            bool flag = false;
            UserInfo user = dalUser.GetUserInfoByUserID(LoginUserName);
            if(user!=null)
            {
                if(UserPwd== user.UserPwd )
                {
                    flag = true;
                    msg = "登录成功！";
                }
                else
                {
                    flag = false;
                    msg = "密码错误！";
                }
            }
            else
            {
                flag = false;
                msg = "用户不存在！";
            }
            return flag;
        }
        #endregion
        #endregion
    }
}
