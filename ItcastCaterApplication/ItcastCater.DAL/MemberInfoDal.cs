/// <summary>
/// DAL
/// </summary>
namespace ItcastCater.DAL
{
    #region reference namespace
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Text; 
    #endregion

    /// <summary>
    /// DAL MemberInfoDAL
    /// </summary>
    public class MemberInfoDAL
    {
        #region 根据会员的名字或者编号查找会员
        /// <summary>
        /// 根据会员的名字或者编号查找会员
        /// </summary>
        /// <param name="name">查询信息</param>
        /// <param name="temp">查询标识， 1：根据会员名字查询，2：根据会员编号查询</param>
        /// <returns>list</returns>
        public List<MemberInfo> GetMemberInfoByNameOrNum(string name, int temp)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM MemberInfo WHERE DelFlag=0 ");
            if (temp == 1)
            {
                sql.Append(" AND MemName LIKE @MemName");
            }
            else if (temp == 2)
            {
                sql.Append(" AND MemNum LIKE @MemName");
            }
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@MemName", SqlDbType.VarChar, 32) { Value = name });
            List<MemberInfo> list = new List<MemberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberInfo(dr));
                }
            }
            return list;
        }
        #endregion

        #region 根据会员ID更新会员卡内余额
        /// <summary>
        /// 根据会员ID更新会员卡内余额
        /// </summary>
        /// <param name="memberID">会员ID</param>
        /// <param name="memMoney">卡内余额</param>
        /// <returns>受影响的行数</returns>
        public int UpdateMoneyByMemID(int memberID, decimal memMoney)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE MemberInfo SET MemMoney=@MemMoney WHERE DelFlag=0 AND MemberID=@MemberID");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@MemMoney",SqlDbType.Decimal,18) {Value=memMoney },
                new SqlParameter("@MemberID",SqlDbType.Int) {Value=memberID }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, pms);
        }
        #endregion

        #region 根据会员的ID查询会员的级别
        /// <summary>
        /// 根据会员的ID查询会员的级别
        /// </summary>
        /// <param name="memberID">会员ID</param>
        /// <returns>会员级别名称</returns>
        public string GetMemberTypeNameByMemberID(int memberID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT MemTpName FROM MemberType AS m1 INNER JOIN MemberInfo AS m2 ON m2.MemType=m1.MemType WHERE m2.MemberID=@MemberID");
            return SqlHelper.ExecuteScalar(sql.ToString(), CommandType.Text, new SqlParameter("@MemberID", SqlDbType.Int) { Value = memberID }).ToString();
        }
        #endregion

        #region 根据ID查询对象
        /// <summary>
        /// 根据ID查询对象
        /// </summary>
        /// <param name="memberID">会员ID</param>
        /// <returns>对象</returns>
        public MemberInfo GetMemberInfoByMemberID(int memberID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM MemberInfo WHERE DelFlag=0");
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text);
            MemberInfo mem = null;
            if (dt.Rows.Count > 0)
            {
                mem = RowToMemberInfo(dt.Rows[0]);
            }
            return mem;
        }
        #endregion

        #region 根据删除标识获取会员列表
        /// <summary>
        /// 根据删除标识获取会员列表
        /// </summary>
        /// <param name="delFlag">删除标识 0:未删除，1：已删除（逻辑删除）</param>
        /// <returns>list</returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int delFlag)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT m.MemberID,m.MemName,m.MemMobilePhone,m.MemAddress,m.MemType,m.MemNum,m.MemGender,m.MemDiscount,m.MemMoney,m.SubTime,m.MemIntegral,m.MemEndServerTime,m.MemBirthday FROM MemberInfo AS m WHERE m.DelFlag=@DelFlag");
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@DelFlag", SqlDbType.SmallInt) { Value = delFlag });
            List<MemberInfo> list = new List<MemberInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberInfo(dr));
                }
            }
            return list;
        }
        #endregion

        #region 关系转对象
        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>model</returns>
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

        #region 新增会员
        /// <summary>
        /// 新增会员
        /// </summary>
        /// <param name="mem">MemberInfo实体对象</param>
        /// <returns>受影响的行数</returns>
        public int AddMemmberInfo(MemberInfo mem)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO MemberInfo (MemName,MemMobilePhone,MemAddress,MemType,MemNum,MemGender,MemDiscount,MemMoney,DelFlag,SubTime,MemIntegral,MemEndServerTime,MemBirthdaty) values(@MemName,@MemMobilePhone,@MemAddress,@MemType,@MemNum,@MemGender,@MemDiscount,@MemMoney,@DelFlag,@SubTime,@MemIntegral,@MemEndServerTime,@MemBirthday)");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@MemName",SqlDbType.VarChar,32) {Value=mem.MemName },
                new SqlParameter("@MemMobilePhone",SqlDbType.VarChar,32) {Value=mem.MemMobilePhone },
                new SqlParameter("@MemAddress",SqlDbType.VarChar,64) {Value=mem.MemAddress },
                new SqlParameter("@MemType",SqlDbType.SmallInt) {Value=mem.MemType },
                new SqlParameter("@MemNum",SqlDbType.VarChar,32) {Value=mem.MemNum },
                new SqlParameter("@MemGender",SqlDbType.Char,1) {Value=mem.MemGender },
                new SqlParameter("@MemDiscount",SqlDbType.Decimal,18) {Value=mem.MemDiscount },
                new SqlParameter("@MemMoney",SqlDbType.Decimal,18) {Value=mem.MemMoney },
                new SqlParameter("@DelFlag",SqlDbType.SmallInt) {Value=mem.DelFlag },
                new SqlParameter("@SubTime",SqlDbType.Date) {Value=mem.SubTime },
                new SqlParameter("@MemIntegral",SqlDbType.VarChar) {Value=mem.MemIntegral },
                new SqlParameter("@MemEndServerTime",SqlDbType.Date) {Value=mem.MemEndServerTime },
                new SqlParameter("@MemBirthday",SqlDbType.Date) {Value=mem.MemBirthday }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, pms);
        }
        #endregion

        #region 修改会员信息
        /// <summary>
        /// 修改会员信息
        /// </summary>
        /// <param name="mem">MemberInfo实体对象</param>
        /// <returns>受影响的行数</returns>
        public int UpdateMemmberInfo(MemberInfo mem)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE MemmberInfo SET MemName=@MemName,MemMobilePhone=@MemMobilePhone,MemAddress=@MemAddress,MemType=@MemType,MemNum=@MemNum,MemGender=@MemGender,MemDiscount=@MemDiscount,MemMoney=@MemMoney,MemIntegral=@MemIntegral,MemEndServerTime=@MemEndServerTime,MemBirthdaty=@MemBirthdaty where MemberID=@MemberID");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@MemName",SqlDbType.VarChar,32) {Value=mem.MemName },
                new SqlParameter("@MemMobilePhone",SqlDbType.VarChar,32) {Value=mem.MemMobilePhone },
                new SqlParameter("@MemAddress",SqlDbType.VarChar,64) {Value=mem.MemAddress },
                new SqlParameter("@MemType",SqlDbType.SmallInt) {Value=mem.MemType },
                new SqlParameter("@MemNum",SqlDbType.VarChar,32) {Value=mem.MemNum },
                new SqlParameter("@MemGender",SqlDbType.Char,1) {Value=mem.MemGender },
                new SqlParameter("@MemDiscount",SqlDbType.Decimal,18) {Value=mem.MemDiscount },
                new SqlParameter("@MemMoney",SqlDbType.Decimal,18) {Value=mem.MemMoney },
                new SqlParameter("@MemIntegral",SqlDbType.VarChar) {Value=mem.MemIntegral },
                new SqlParameter("@MemEndServerTime",SqlDbType.Date) {Value=mem.MemEndServerTime },
                new SqlParameter("@MemBirthday",SqlDbType.Date) {Value=mem.MemBirthday },
                new SqlParameter("@MemberID",SqlDbType.Int) {Value=mem.MemberID }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, pms);
        }
        #endregion

        #region 删除会员--逻辑删除
        /// <summary>
        /// 删除会员-逻辑删除
        /// 根据ID修改删除标识
        /// </summary>
        /// <param name="memberID">会员ID</param>
        /// <returns>受影响的行数</returns>
        public int DeleteMemberInfoByMemberID(int memberID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE MemberInfo SET DelFlag=1 WHERE MemberID=@MemberID");
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, new SqlParameter("@MemberID", SqlDbType.Int) { Value = memberID });
        }
        #endregion
    }
}
