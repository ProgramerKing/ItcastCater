namespace ItcastCater.Models
{
    /// <summary>
    /// 会员类型
    /// </summary>
    public class MemberType
    {
        #region Model
        private int _MemType;
        private string _MemTpName;
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
        #endregion
    }
}
