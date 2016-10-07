/// <summary>
/// Model
/// </summary>
namespace ItcastCater.Models
{
    /// <summary>
    /// 会员类型类
    /// </summary>
    public class MemberType
    {
        #region Model
        private int _MemType;
        private string _MemTpName;
        private string _MemTpDesc;
        private int? _DelFlag;
        private int? subBy;
        /// <summary>
        /// 会员类型主键
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
        /// 会员类型名称
        /// </summary>
        public string MemTpName
        {
            get
            {
                return _MemTpName;
            }

            set
            {
                _MemTpName = value;
            }
        }
        /// <summary>
        /// 会员类型简介
        /// </summary>
        public string MemTpDesc
        {
            get
            {
                return _MemTpDesc;
            }

            set
            {
                _MemTpDesc = value;
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
        /// 提交人
        /// </summary>
        public int? SubBy
        {
            get
            {
                return subBy;
            }

            set
            {
                subBy = value;
            }
        }
        #endregion
    }
}
