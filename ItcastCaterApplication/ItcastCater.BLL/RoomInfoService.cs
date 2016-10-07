/// <summary>
/// BLL
/// </summary>
namespace ItcastCater.BLL
{
    using System.Collections.Generic;
    using DAL;
    using Models;
    /// <summary>
    /// BLL RoomInfoService
    /// </summary>
    public class RoomInfoService
    {
        RoomInfoDAL roomDal = new RoomInfoDAL();

        #region 根据删除标识获取房间列表
        /// <summary>
        /// 根据删除标识获取房间列表
        /// </summary>
        /// <param name="delFlag">删除标识，0：未删除，1：已删除</param>
        /// <returns>list</returns>
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            return roomDal.GetAllRoomInfoByDelFlag(delFlag);
        } 
        #endregion
    }
}
