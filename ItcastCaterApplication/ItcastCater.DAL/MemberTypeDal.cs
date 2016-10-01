using System;
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
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            string sql = "SELECT MemType,MemTpName FROM MemberType WHERE DelFlag=@DelFlag";
            DataTable dt = SqlHelper.ExecuteTable(sql, CommandType.Text, new SqlParameter("@DelFlag", SqlDbType.Int) { Value = delFlag });
            List<MemberType> list = new List<MemberType>();
            if(dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToMemberType(dr));
                }
            }
            return list;
        }
        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private MemberType RowToMemberType(DataRow dr)
        {
            MemberType mtp = new MemberType();
            mtp.MemType = Convert.ToInt32(dr["MemType"]);
            mtp.MemTpName = dr["MemTpName"].ToString();
            return mtp;
        }
    }
}
