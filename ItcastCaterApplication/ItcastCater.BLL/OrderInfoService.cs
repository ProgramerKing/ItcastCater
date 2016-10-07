/// <summary>
/// BLL
/// </summary>
namespace ItcastCater.BLL
{
    using System;
    using DAL;
    using Models;
    /// <summary>
    /// BLL OrderInfoService
    /// </summary>
    public class OrderInfoService
    {
        OrderInfoDAL orderDal = new OrderInfoDAL();

        #region 根据餐桌的ID查找该餐桌正在使用的订单ID
        /// <summary>
        /// 根据餐桌的ID查找该餐桌正在使用的订单ID
        /// </summary>
        /// <param name="deskID">餐桌ID</param>
        /// <returns></returns>
        public int GetOrderIDByDeskID(int deskID)
        {
            return Convert.ToInt32(orderDal.GetOrderIdByDeskId(deskID));
        }
        #endregion

        #region 添加一笔订单
        /// <summary>
        /// 添加一笔订单
        /// </summary>
        /// <param name="order">订单对象</param>
        /// <returns></returns>
        public int AddOrderInfo(OrderInfo order)
        {
            return Convert.ToInt32(orderDal.AddOrderInfo(order));
        }
        #endregion
    }
}
