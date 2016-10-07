/// <summary>
/// Model
/// </summary>
namespace ItcastCater.Models
{
    /// <summary>
    /// 订单表与产品表的中间表
    /// </summary>
    public class R_OrderInfo_Product
    {
        private string _ProName;
        private string _ProUnit;
        private decimal? _ProPrice;
        private string _CatName;
        private decimal? _ProMoney;

        /// <summary>
        /// 商品的名字
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
        /// 商品的单位
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
        /// 商品的单价
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
        /// 商品的类别
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
        /// 商品的总价
        /// </summary>
        public decimal? ProMoney
        {
            get
            {
                return _ProMoney;
            }

            set
            {
                _ProMoney = value;
            }
        }
    }
}
