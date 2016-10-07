/// <summary>
/// BLL
/// </summary>
namespace ItcastCater.BLL
{
    using DAL;
    using Models;
    /// <summary>
    /// BLL R_Order_DeskService
    /// </summary>
    public class R_Order_DeskService
    {
        R_Order_DeskDAL dal = new R_Order_DeskDAL();
        /// <summary>
        /// 添加一个中间表的数据
        /// </summary>
        /// <param name="rod"></param>
        /// <returns></returns>
        public bool AddROrderDesk(R_Order_Desk rod)
        {
            return dal.AddROrderDesk(rod) > 0;
        }
    }
}
