using System;

namespace ItcastCater.Models
{
    /// <summary>
    /// 会员信息类
    /// </summary>
    public class MemberInfo
    {
        #region Model
        private int _MemberID;
        private string _MemName;
        private string _MemTelPhone;
        private string _MemMobilePhone;
        private string _MemAddress;
        private int _MemType;
        private string _MemNum;
        private string _MemGender;
        private decimal? _MemDiscount;
        private decimal? _MemMoney;
        private int? _DelFlag;
        private DateTime? _SubTime;
        private int? _MemIntegral;
        private DateTime? _MemEndServerTime;
        private DateTime? _MemBirthday;

        /// <summary>
        /// 会员主键编号
        /// </summary>
        public int MemberID
        {
            get
            {
                return _MemberID;
            }

            set
            {
                _MemberID = value;
            }
        }
        /// <summary>
        /// 会员名字
        /// </summary>
        public string MemName
        {
            get
            {
                return _MemName;
            }

            set
            {
                _MemName = value;
            }
        }
        /// <summary>
        /// 会员电话
        /// </summary>
        public string MemTelPhone
        {
            get
            {
                return _MemTelPhone;
            }

            set
            {
                _MemTelPhone = value;
            }
        }
        /// <summary>
        /// 会员手机
        /// </summary>
        public string MemMobilePhone
        {
            get
            {
                return _MemMobilePhone;
            }

            set
            {
                _MemMobilePhone = value;
            }
        }
        /// <summary>
        /// 会员地址
        /// </summary>
        public string MemAddress
        {
            get
            {
                return _MemAddress;
            }

            set
            {
                _MemAddress = value;
            }
        }
        /// <summary>
        /// 会员类型
        /// </summary>
        public int MemType
        {
            get
            {
                return _MemType;
            }

            set
            {
                _MemType = value;
            }
        }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string MemNum
        {
            get
            {
                return _MemNum;
            }

            set
            {
                _MemNum = value;
            }
        }
        /// <summary>
        /// 会员性别
        /// </summary>
        public string MemGender
        {
            get
            {
                return _MemGender;
            }

            set
            {
                _MemGender = value;
            }
        }
        /// <summary>
        /// 会员折扣
        /// </summary>
        public decimal? MemDiscount
        {
            get
            {
                return _MemDiscount;
            }

            set
            {
                _MemDiscount = value;
            }
        }
        /// <summary>
        /// 会员余额
        /// </summary>
        public decimal? MemMoney
        {
            get
            {
                return _MemMoney;
            }

            set
            {
                _MemMoney = value;
            }
        }
        /// <summary>
        /// 会员删除标识
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
        /// <summary>
        /// 会员提交时间
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
        /// 会员积分
        /// </summary>
        public int? MemIntegral
        {
            get
            {
                return _MemIntegral;
            }

            set
            {
                _MemIntegral = value;
            }
        }
        /// <summary>
        /// 会员结束时间
        /// </summary>
        public DateTime? MemEndServerTime
        {
            get
            {
                return _MemEndServerTime;
            }

            set
            {
                _MemEndServerTime = value;
            }
        }
        /// <summary>
        /// 会员生日
        /// </summary>
        public DateTime? MemBirthday
        {
            get
            {
                return _MemBirthday;
            }

            set
            {
                _MemBirthday = value;
            }
        } 
        #endregion
    }
}
