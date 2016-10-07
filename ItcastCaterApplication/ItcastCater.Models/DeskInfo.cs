/// <summary>
/// Model
/// </summary>
namespace ItcastCater.Models
{
    using System;
    /// <summary>
    /// 餐桌信息类
    /// </summary>
    public class DeskInfo
    {
        #region Model
        private string _DeskStateString;
        private int _DeskID;
        private int _RoomID;
        private string _DeskName;
        private string _DeskRemark;
        private string _DeskRegion;
        private int? _DeskState;
        private int? _DelFlag;
        private DateTime? _SubTime;
        private int? _SubBy;

        /// <summary>
        /// 餐桌的字符串数据
        /// </summary>
        public string DeskStateString
        {
            get
            {
                return _DeskStateString;
            }

            set
            {
                _DeskStateString = value;
            }
        }
        /// <summary>
        /// 餐桌编号
        /// </summary>
        public int DeskID
        {
            get
            {
                return _DeskID;
            }

            set
            {
                _DeskID = value;
            }
        }
        /// <summary>
        /// 房间编号
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
        /// 餐桌的名字
        /// </summary>
        public string DeskName
        {
            get
            {
                return _DeskName;
            }

            set
            {
                _DeskName = value;
            }
        }
        /// <summary>
        /// 描述
        /// </summary>
        public string DeskRegion
        {
            get
            {
                return _DeskRegion;
            }

            set
            {
                _DeskRegion = value;
            }
        }
        /// <summary>
        /// 餐桌的状态
        /// </summary>
        public int? DeskState
        {
            get
            {
                return _DeskState;
            }

            set
            {
                _DeskState = value;
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
        /// <summary>
        /// 提交时间
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
        /// 提交人
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

        public string DeskRemark
        {
            get
            {
                return _DeskRemark;
            }

            set
            {
                _DeskRemark = value;
            }
        }
        #endregion
    }
}
