/// <summary>
/// DAL
/// </summary>
namespace ItcastCater.DAL
{
    #region reference namespace
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using Models;
    using System.Text; 
    #endregion

    /// <summary>
    /// DAL UserInfoDAL
    /// </summary>
    public class UserInfoDAL
    {
        //检查登录是否成功

        #region 用户登录
        /// <summary>
        /// 用户登录 一
        /// </summary>
        /// <param name="LoginUserName">登录名</param>
        /// <param name="UserPwd">登录密码</param>
        /// <returns></returns>
        public int IsLoginByLoginName(string LoginUserName, string UserPwd)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT COUNT(*) FROM UserInfo AS u WHERE u.LoginUserName=@LoginUserName AND u.UserPwd=@UserPwd");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@UserName",SqlDbType.NVarChar,16) {Value=LoginUserName },
                new SqlParameter("@UserPwd",SqlDbType.VarChar,200) {Value=UserPwd }
            };
            return (int)SqlHelper.ExecuteScalar(sql.ToString(), CommandType.Text, pms);
        }
        #endregion

        #region 用户登录2
        /// <summary>
        /// 用户登录 二  根据账号从数据库查询，返回的是对象
        /// </summary>
        /// <param name="LoginUserName"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoByUserID(string LoginUserName)
        {
            UserInfo model = null;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT u.UserID,u.LoginUserName,u.UserPwd,u.DelFlag FROM UserInfo AS u WHERE u.LoginUserName=@LoginUserName");
            #region 写法一
            //using (SqlDataReader reader = SqlHelper.ExecuteReader(sql.ToString(), CommandType.Text, new SqlParameter("@LoginUserName", SqlDbType.NVarChar) { Value = LoginUserName }))
            //{
            //    if (reader.HasRows)
            //    {
            //        if (reader.Read())
            //        {
            //            model = new UserInfo();
            //            model.UserID = reader.GetInt32(0);
            //            model.UserName = reader.GetString(1);
            //            model.UserPwd = reader.GetString(2);
            //        }
            //    }
            //} 
            #endregion

            #region 写法二
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@LoginUserName", SqlDbType.VarChar, 32) { Value = LoginUserName });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model = RowToUserInfo(dr);
                }
            }
            #endregion

            return model;
        }

        #region 关系转对象
        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>model</returns>
        private UserInfo RowToUserInfo(DataRow dr)
        {
            UserInfo user = new UserInfo();
            user.UserID = Convert.ToInt32(dr["UserID"]);
            user.LoginUserName = dr["LoginUserName"].ToString();
            user.UserPwd = dr["UserPwd"].ToString();
            user.DelFlag = Convert.ToInt32(dr["DelFlag"]);

            return user;
        }
        #endregion
        #endregion
    }
}
