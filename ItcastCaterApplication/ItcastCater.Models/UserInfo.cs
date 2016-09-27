using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.Models
{
    public class UserInfo
    {
        private int _UserID;
        private string _UserName;
        private string _LoginUserName;
        private string _UserPwd;
        private DateTime? _LastLoginTime;
        private string _LastLoginIP;
        private int? _DelFlag;
        private DateTime? _SubTime;
        private int? _SubBy;
        /// <summary>
        /// 用户主键
        /// </summary>
        public int UserID
        {
            get
            {
                return _UserID;
            }

            set
            {
                _UserID = value;
            }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            get
            {
                return _UserName;
            }

            set
            {
                _UserName = value;
            }
        }
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginUserName
        {
            get
            {
                return _LoginUserName;
            }

            set
            {
                _LoginUserName = value;
            }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPwd
        {
            get
            {
                return _UserPwd;
            }

            set
            {
                _UserPwd = value;
            }
        }
        /// <summary>
        /// 上一次登录时间
        /// </summary>
        public DateTime? LastLoginTime
        {
            get
            {
                return _LastLoginTime;
            }

            set
            {
                _LastLoginTime = value;
            }
        }
        /// <summary>
        /// 上一次登录IP
        /// </summary>
        public string LastLoginIP
        {
            get
            {
                return _LastLoginIP;
            }

            set
            {
                _LastLoginIP = value;
            }
        }
        /// <summary>
        /// 用户删除标识
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
        /// 用户提交时间
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
    }
}
