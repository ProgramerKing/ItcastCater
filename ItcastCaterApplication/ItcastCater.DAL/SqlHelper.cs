/// <summary>
/// DAL
/// </summary>
namespace ItcastCater.DAL
{
    #region reference namespace
    using System;
    using System.Data;
    using System.Data.SqlClient; 
    #endregion
    /// <summary>
    /// SQL Helper
    /// </summary>
    public class SqlHelper
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static readonly string ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["ItcastCaterDB"].ConnectionString;

        #region 返回受影响行数
        /// <summary>
        /// 返回受影响行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="pms">SQL可变参数组</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        #endregion

        #region 返回首行首列
        /// <summary>
        /// 返回首行首列
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="pms">SQL可变参数组</param>
        /// <returns>返回首行首列Object</returns>
        public static object ExecuteScalar(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlConnection con = new SqlConnection(ConStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = cmdType;
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }
        #endregion

        #region 返回DataReader
        /// <summary>
        /// 返回DataReader
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="pms">SQL可变参数组</param>
        /// <returns>table</returns>
        public static SqlDataReader ExecuteReader(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            SqlConnection con = new SqlConnection(ConStr);
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = cmdType;
                if (pms != null)
                {
                    cmd.Parameters.AddRange(pms);
                }

                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch (Exception)
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }
        #endregion

        #region 执行返回DataTable
        /// <summary>
        /// 执行返回DataTable
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="cmdType">SQL语句类型</param>
        /// <param name="pms">SQL可变参数组</param>
        /// <returns></returns>
        public static DataTable ExecuteTable(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, ConStr))
            {
                adapter.SelectCommand.CommandType = cmdType;
                if (pms != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }
        #endregion
    }
}
