/// <summary>
/// Model
/// </summary>
namespace ItcastCater.Models
{
    using System;

    /// <summary>
    /// 房间信息类
    /// </summary>
    public class RoomInfo
    {
        private int _RoomID;
        private string _RoomName;
        private int? _RoomType;
        private decimal? _RoomMinimunConsume;
        private decimal? _RoomMaxCounsumer;
        private int? _IsDefault;
        private int? _DelFlag;
        private DateTime? _SubTime;
        private int? _SubBy;
        /// <summary>
        /// 房间编号主键
        /// </summary>
        public int RoomID
        {
            get
            {
                return _RoomID;
            }

            set
            {
                _RoomID = value;
            }
        }
        /// <summary>
        /// 房间名称
        /// </summary>
        public string RoomName
        {
            get
            {
                return _RoomName;
            }

            set
            {
                _RoomName = value;
            }
        }
        /// <summary>
        /// 房间类型
        /// </summary>
        public int? RoomType
        {
            get
            {
                return _RoomType;
            }

            set
            {
                _RoomType = value;
            }
        }
        /// <summary>
        /// 最低消费
        /// </summary>
        public decimal? RoomMinimunConsume
        {
            get
            {
                return _RoomMinimunConsume;
            }

            set
            {
                _RoomMinimunConsume = value;
            }
        }
        /// <summary>
        /// 最高消费
        /// </summary>
        public decimal? RoomMaxCounsumer
        {
            get
            {
                return _RoomMaxCounsumer;
            }

            set
            {
                _RoomMaxCounsumer = value;
            }
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int? IsDefault
        {
            get
            {
                return _IsDefault;
            }

            set
            {
                _IsDefault = value;
            }
        }
        /// <summary>
        /// 房间删除标识
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
        /// 房间提交时间
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
        /// 房间提交人
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
    }
}
