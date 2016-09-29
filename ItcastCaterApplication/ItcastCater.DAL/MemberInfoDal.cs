using ItcastCater.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ItcastCater.DAL
{
    public class MemberInfoDal
    {
        #region 根据删除标识获取会用列表
        /// <summary>
        /// 根据删除标识获取会用列表
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns>list</returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int delFlag)
        {
            string sql = "SELECT m.MemberID,m.MemName,m.MemMobilePhone,m.MemAddress,m.MemType,m.MemNum,m.MemGender,m.MemDiscount,m.MemMoney,m.SubTime,m.MemIntegral,m.MemEndServerTime,m.MemBirthday FROM MemberInfo AS m WHERE m.DelFlag=@DelFlag";
            DataTable dt = SqlHelper.ExecuteTable(sql, CommandType.Text, new SqlParameter("@DelFlag", SqlDbType.SmallInt) { Value = delFlag });
            List<MemberInfo> list = new List<MemberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MemberInfo mem = RowToMemberInfo(dr);
                    list.Add(mem);
                }
            }
            return list;
        } 
        #endregion

        #region 关系转对象
        private MemberInfo RowToMemberInfo(DataRow dr)
        {
            MemberInfo mem = new MemberInfo();
            mem.MemberID = Convert.ToInt32(dr["MemberID"]);
            mem.MemName = dr["MemName"].ToString();
            mem.MemMobilePhone = dr["MemMobilePhone"].ToString();
            mem.MemAddress = dr["MemAddress"].ToString();
            mem.MemType = Convert.ToInt32(dr["MemType"]);
            mem.MemNum = dr["MemNum"].ToString();
            mem.MemGender = dr["MemGender"].ToString();
            mem.MemDiscount = Convert.ToInt32(dr["MemDiscount"]);
            mem.MemMoney = Convert.ToInt32(dr["MemMoney"]);
            mem.SubTime = (DateTime)(dr["SubTime"]);
            mem.MemIntegral = Convert.ToInt32(dr["MemIntegral"]);
            mem.MemEndServerTime = (DateTime)(dr["MemEndServerTime"]);
            mem.MemBirthday = (DateTime)(dr["MemBirthday"]);
            return mem;
        } 
        #endregion
    }
}
