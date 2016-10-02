using System;

namespace ItcastCater.Models
{
    /// <summary>
    /// 订单信息类
    /// </summary>
    public class OrderInfo
    {
        #region Model
        private int _OrderID;
        private DateTime ? _SubTime;
        private string _Remark;
        private int ? _OrderState;
        private int ? _SubBy;
        private int ? _OrderMemID;
        private DateTime? _BeginTime;
        private DateTime? _EndTime;
        private decimal? _OrderMoney;
        private decimal? _Discount;
        private int? _DelFlag;
        /// <summary>
        /// 订单主键
        /// </summary>
        public int OrderID
        {
            get
            {
                return _OrderID;
            }

            set
            {
                _OrderID = value;
            }
        }
        /// <summary>
        /// 订单提交时间
        /// </summary>
        public DateTime? SubTime
        {
            get
            {
                return _SubTime;
            }

            set
            {
                _SubTime = value;
            }
        }
        /// <summary>
        /// 订单备注
        /// </summary>
        public string Remark
        {
            get
            {
                return _Remark;
            }

            set
            {
                _Remark = value;
            }
        }
        /// <summary>
        /// 订单状态
        /// </summary>
        public int? OrderState
        {
            get
            {
                return _OrderState;
            }

            set
            {
                _OrderState = value;
            }
        }
        /// <summary>
        /// 提单提交人
        /// </summary>
        public int? SubBy
        {
            get
            {
                return _SubBy;
            }

            set
            {
                _SubBy = value;
            }
        }
        /// <summary>
        /// 订单会员编号
        /// </summary>
        public int? OrderMemID
        {
            get
            {
                return _OrderMemID;
            }

            set
            {
                _OrderMemID = value;
            }
        }
        /// <summary>
        /// 订单开始时间
        /// </summary>
        public DateTime? BeginTime
        {
            get
            {
                return _BeginTime;
            }

            set
            {
                _BeginTime = value;
            }
        }
        /// <summary>
        /// 订单结束时间
        /// </summary>
        public DateTime? EndTime
        {
            get
            {
                return _EndTime;
            }

            set
            {
                _EndTime = value;
            }
        }
        /// <summary>
        /// 订单消费总金额
        /// </summary>
        public decimal? OrderMoney
        {
            get
            {
                return _OrderMoney;
            }

            set
            {
                _OrderMoney = value;
            }
        }
        /// <summary>
        /// 折扣
        /// </summary>
        public decimal? Discount
        {
            get
            {
                return _Discount;
            }

            set
            {
                _Discount = value;
            }
        }
        /// <summary>
        /// 删除标识
        /// </summary>
        public int? DelFlag
        {
            get
            {
                return _DelFlag;
            }

            set
            {
                _DelFlag = value;
            }
        }
        #endregion
    }
}
