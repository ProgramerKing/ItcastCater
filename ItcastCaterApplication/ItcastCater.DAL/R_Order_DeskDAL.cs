/// <summary>
/// DAL
/// </summary>
namespace ItcastCater.DAL
{
    #region reference namespace
    using Models;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text; 
    #endregion

    /// <summary>
    /// DAL R_Order_DeskDAL
    /// </summary>
    public class R_Order_DeskDAL
    {
        /// <summary>
        /// 添加一个中间表的数据
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        public int AddROrderDesk(R_Order_Desk rod)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO R_Order_Desk (OderID,DeskID) VALUES(@OrderID,@DeskID)");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@OrderID",SqlDbType.Int) {Value=rod.OrderID },
                new SqlParameter("@DeskID",SqlDbType.Int) {Value=rod.DeskID }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text,pms);
        }
    }
}
