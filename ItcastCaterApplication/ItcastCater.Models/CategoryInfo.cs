/// <summary>
/// Model
/// </summary>
namespace ItcastCater.Models
{
    using System;
    /// <summary>
    /// 商品分类
    /// </summary>
    public class CategoryInfo
    {
        #region Model
        private int _CatID;
        private string _CatName;
        private string _CatNum;
        private string _Remark;
        private int? _DelFlag;
        private DateTime? _SubTime;
        private int? _SubBy;

        /// <summary>
        /// 商品分类主键
        /// </summary>
        public int CatID
        {
            get
            {
                return _CatID;
            }

            set
            {
                _CatID = value;
            }
        }
        /// <summary>
        /// 商品分类名字
        /// </summary>
        public string CatName
        {
            get
            {
                return _CatName;
            }

            set
            {
                _CatName = value;
            }
        }
        /// <summary>
        /// 商品分类编号
        /// </summary>
        public string CatNum
        {
            get
            {
                return _CatNum;
            }

            set
            {
                _CatNum = value;
            }
        }
        /// <summary>
        /// 商品分类备注
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
        /// 商品分类删除标识
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
        /// 商品分类提交时间
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
        /// 商品分类提交人
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

        
        #endregion
    }
}
