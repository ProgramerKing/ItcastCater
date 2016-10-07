/// <summary>
/// DAL
/// </summary>
namespace ItcastCater.DAL
{
    #region reference namespace
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using Models; 
    #endregion
    
    /// <summary>
    /// DAL MemberTypeDAL
    /// </summary>
    public class MemberTypeDAL
    {
        #region 根据删除标识获取会员类别列表
        /// <summary>
        /// 根据删除标识获取会员类别列表
        /// </summary>
        /// <param name="delFlag">删除标识 0:未删除，1：已删除（逻辑删除）</param>
        /// <returns>list</returns>
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT MemType,MemTpName FROM MemberType WHERE DelFlag=@DelFlag");
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@DelFlag", SqlDbType.Int) { Value = delFlag });
            List<MemberType> list = new List<MemberType>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberType(dr));
                }
            }
            return list;
        }
        #region 关系转对象
        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>model</returns>
        private MemberType RowToMemberType(DataRow dr)
        {
            MemberType mtp = new MemberType();
            mtp.MemType = Convert.ToInt32(dr["MemType"]);
            mtp.MemTpName = dr["MemTpName"].ToString();
            return mtp;
        } 
        #endregion
        #endregion
    }
}
