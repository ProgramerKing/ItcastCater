﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ItcastCater.Models;

namespace ItcastCater.DAL
{
    public class MemberTypeDal
    {
        #region 根据删除标识查询所有会员类别
        /// <summary>
        /// 根据删除标识查询所有会员类别
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
