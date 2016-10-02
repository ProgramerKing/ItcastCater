using ItcastCater.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ItcastCater.DAL
{
    public class RoomInfoDal
    {
        #region 根据删除标识查询所有房间信息
        /// <summary>
        /// 根据删除标识查询所有房间信息
        /// </summary>
        /// <param name="delFlag">删除标识 0:未删除，1：已删除（逻辑删除）</param>
        /// <returns>list</returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM RoomInfo WHERE DelFlag=@DelFlag");
            List<RoomInfo> list = new List<RoomInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@DelFlag", SqlDbType.Int) { Value = delFlag });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToRoomInfo(dr));
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
        private RoomInfo RowToRoomInfo(DataRow dr)
        {
            RoomInfo room = new RoomInfo();
            room.IsDefault = Convert.ToInt32(dr["IsDefault"]);
            room.RoomID = Convert.ToInt32(dr["RoomID"]);
            room.RoomMaxCounsumer = Convert.ToInt32(dr["RoommMaxCounsumer"]);
            room.RoomMinimunConsume = Convert.ToInt32(dr["RoomMinimunConsume"]);
            room.RoomName = dr["RoomName"].ToString();
            return room;
        } 
        #endregion
        #endregion
    }
}
