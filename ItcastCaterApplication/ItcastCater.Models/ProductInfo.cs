using System;

namespace ItcastCater.Models
{
    /// <summary>
    /// 商品信息类
    /// </summary>
    public class ProductInfo
    {
        #region Model
        private int _ProID;
        private int? _CatID;
        private string _ProName;
        private decimal? _ProCost;
        private string _ProSpell;
        private decimal? _ProPrice;
        private string _ProUnit;
        private string _Remark;
        private int? _DelFlag;
        private DateTime? _SubTime;
        private decimal? _ProStock;
        private string _ProNum;
        private int _SubBy;
        /// <summary>
        /// 商品主键
        /// </summary>
        public int ProID
        {
            get
            {
                return _ProID;
            }

            set
            {
                _ProID = value;
            }
        }
        /// <summary>
        /// 商品类型编号
        /// </summary>
        public int? CatID
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
        /// 商品名字
        /// </summary>
        public string ProName
        {
            get
            {
                return _ProName;
            }

            set
            {
                _ProName = value;
            }
        }
        /// <summary>
        /// 商品成本
        /// </summary>
        public decimal? ProCost
        {
            get
            {
                return _ProCost;
            }

            set
            {
                _ProCost = value;
            }
        }
        /// <summary>
        /// 商品拼音
        /// </summary>
        public string ProSpell
        {
            get
            {
                return _ProSpell;
            }

            set
            {
                _ProSpell = value;
            }
        }
        /// <summary>
        /// 商品实际价格
        /// </summary>
        public decimal? ProPrice
        {
            get
            {
                return _ProPrice;
            }

            set
            {
                _ProPrice = value;
            }
        }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string ProUnit
        {
            get
            {
                return _ProUnit;
            }

            set
            {
                _ProUnit = value;
            }
        }
        /// <summary>
        /// 商品备注
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
        /// 商品删除标识
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
        /// 商品提交时间
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
        /// 商品库存
        /// </summary>
        public decimal? ProStock
        {
            get
            {
                return _ProStock;
            }

            set
            {
                _ProStock = value;
            }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProNum
        {
            get
            {
                return _ProNum;
            }

            set
            {
                _ProNum = value;
            }
        }
        /// <summary>
        /// 商品提交人
        /// </summary>
        public int SubBy
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
