using System;
using System.Collections.Generic;
using System.Text;
using ItcastCater.Models;
using System.Data;
using System.Data.SqlClient;

namespace ItcastCater.DAL
{
    public class DeskInfoDal
    {
        #region 更改餐桌状态
        /// <summary>
        /// 更改餐桌状态
        /// </summary>
        /// <param name="deskID">餐桌编号</param>
        /// <param name="deskState">餐桌状态</param>
        /// <returns>受影响的行数</returns>
        public int UpdateDeskStateByDeskID(int deskID, int deskState)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE DeskInfo SET DeskState=@DeskState WHERE DelFlag=0 AND DeskID=@DeskID");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@DeskState",SqlDbType.SmallInt) {Value= deskState},
                new SqlParameter("@DeskID",SqlDbType.Int) {Value=deskID }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, pms);
        }
        #endregion

        #region 根据房间的ID查询该房间下的餐桌
        /// <summary>
        /// 根据房间的ID查询该房间下的餐桌
        /// </summary>
        /// <param name="roomID">房间编号</param>
        /// <returns>list</returns>
        public List<DeskInfo> GetAllDeskInfoByRoomID(int roomID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM DeskInfo WHERE RoomID=@RoomID");
            List<DeskInfo> list = new List<DeskInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@RoomID", SqlDbType.Int) { Value = roomID });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToDeskInfo(dr));
                }
            }
            return list;
        }

        private DeskInfo RowToDeskInfo(DataRow dr)
        {
            DeskInfo desk = new DeskInfo();
            desk.DeskID = Convert.ToInt32(dr["DeskID"]);
            desk.RoomID = Convert.ToInt32(dr["RoomID"]);
            desk.DeskName = dr["DeskName"].ToString();
            desk.DeskRemark = dr["DeskRemark"].ToString();
            desk.DeskRegion = dr["DeskRegion"].ToString();
            desk.DeskState = Convert.ToInt32(dr["DeskState"]);
            desk.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            desk.SubTime = (DateTime)dr["SubTime"];
            desk.SubBy = Convert.ToInt32(dr["SubBy"]);
            return desk;
        }
        #endregion
    }
}
