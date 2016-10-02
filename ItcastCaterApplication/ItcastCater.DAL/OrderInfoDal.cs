using ItcastCater.Models;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.DAL
{
    public class OrderInfoDal
    {
        #region 更新订单
        /// <summary>
        /// 更新订单
        /// </summary>
        /// <param name="order">实体对象</param>
        /// <returns>受影响的行数</returns>
        public int UpdateOrderInfo(OrderInfo order)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE OrderInfo SET OrderState=2,OrderMemId=@OrderMemId,EndTime=@EndTime,OrderMoney=@OrderMoney,DisCount=@DisCount WHERE OrderId=@OrderId");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@OrderMemId",SqlDbType.Int) {Value= order.OrderMemID},
                new SqlParameter("@EndTime",SqlDbType.Date) {Value=order.EndTime },
                new SqlParameter("@OrderMoney",SqlDbType.Decimal,18) {Value=order.OrderMoney },
                new SqlParameter("@DisCount",SqlDbType.Decimal,18) {Value=order.Discount },
                new SqlParameter("@OrderId",SqlDbType.Int) {Value=order.OrderID }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, pms);
        }
        #endregion

        #region 根据订单ID查询订单的消费金额
        /// <summary>
        /// 根据订单ID查询订单的消费金额
        /// </summary>
        /// <param name="orderID">订单ID</param>
        /// <returns>object</returns>
        public object GetOrderMoneyByOrderID(int orderID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT OrderMoney FROM OrderInfo WHERE OrderID=@OrderID AND OrderState=1 AND DelFlag=0");
            return SqlHelper.ExecuteScalar(sql.ToString(), CommandType.Text, new SqlParameter("@OrderID", SqlDbType.Int) { Value = orderID });
        }
        #endregion

        #region 根据订单的ID和消费的金额进行更新
        /// <summary>
        /// 根据订单的ID和消费的金额进行更新
        /// </summary>
        /// <param name="orderID">订单的ID</param>
        /// <param name="orderMoney">金额</param>
        /// <returns></returns>
        public int UpdateMoney(int orderID, decimal orderMoney)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE OrderInfo SET OrderMoney=@OrderMoney WHERE OrderId=@OrderId and DelFlag=0");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@OrderMoney",SqlDbType.Decimal,18) {Value=orderMoney },
                new SqlParameter("@OrderID",SqlDbType.Int) {Value=orderID }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, pms);
        }
        #endregion

        #region 根据餐桌的ID查找该餐桌正在使用的订单ID
        /// <summary>
        /// 根据餐桌的ID查找该餐桌正在使用的订单ID
        /// </summary>
        /// <param name="deskID">餐桌的ID</param>
        /// <returns>订单的ID</returns>
        public object GetOrderIdByDeskId(int deskID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT o.OrderId FROM R_Order_Desk AS r inner join OrderInfo AS o ON r.OrderID=o.OrderID WHERE OrderInfo.OrderState=1 AND DeskID=@DeskID");
            return SqlHelper.ExecuteScalar(sql.ToString(), CommandType.Text, new SqlParameter("@DeskID", SqlDbType.Int) { Value = deskID });
        }
        #endregion

        #region 添加一个订单
        /// <summary>
        /// 添加一个订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public object AddOrderInfo(OrderInfo order)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO OrderInfo (SubTime,Remark,OrderState,DelFlag,SubBy,OrderMoney) values(@SubTime,@Remark,@OrderState,@DelFlag,@SubBy,@OrderMoney) SELECT LAST_INSERT_ROWID()");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@SubTime",SqlDbType.Date) {Value=order.SubTime},
                new SqlParameter("@Remark",SqlDbType.VarChar,128) {Value=order.Remark},
                new SqlParameter("@OrderState",SqlDbType.SmallInt) {Value=order.OrderState},
                new SqlParameter("@DelFlag",SqlDbType.SmallInt) {Value=order.DelFlag},
                new SqlParameter("@SubBy",SqlDbType.Int) {Value=order.SubBy},
                new SqlParameter("@OrderMoney",SqlDbType.Decimal,18) {Value=order.OrderMoney}
            };
            return SqlHelper.ExecuteScalar(sql.ToString(), CommandType.Text, pms);
        } 
        #endregion
    }
}
