/// <summary>
/// BLL
/// </summary>
namespace ItcastCater.BLL
{
    using DAL;
    using Models;
    using System.Collections.Generic;

    /// <summary>
    /// BLL DeskInfo
    /// </summary>
    public class DeskInfoService
    {
        DeskInfoDAL deskDal = new DeskInfoDAL();

        #region 根据餐桌ID更改餐桌的状态
        /// <summary>
        /// 根据餐桌ID更改餐桌的状态
        /// </summary>
        /// <param name="deskID">餐桌ID</param>
        /// <param name="deskState">餐桌状态</param>
        /// <returns>bool</returns>
        public bool UpdateDeskStateByDeskID(int deskID, int deskState)
        {
            return deskDal.UpdateDeskStateByDeskID(deskID, deskState) > 0;
        }
        #endregion

        #region 根据房间的ID查询该房间下的餐桌
        /// <summary>
        /// 根据房间的ID查询该房间下的餐桌
        /// </summary>
        /// <param name="roomID">房间ID</param>
        /// <returns>list</returns>
        public List<DeskInfo> GetAllDeskInfoByRoomID(int roomID)
        {
            return deskDal.GetAllDeskInfoByRoomID(roomID);
        }
        #endregion
    }
}
