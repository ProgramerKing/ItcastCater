/// <summary>
/// BLL
/// </summary>
namespace ItcastCater.BLL
{
    using DAL;
    using Models;
    using System.Collections.Generic;
    public class MemberTypeService
    {
        MemberTypeDAL mtpDal = new MemberTypeDAL();

        #region 根据删除标识获取会员类别列表
        /// <summary>
        /// 根据删除标识获取会员类别列表
        /// </summary>
        /// <param name="delFlag">删除标识，0：未删除，1：已删除</param>
        /// <returns>list</returns>
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            return mtpDal.GetAllMemberTypeByDelFlag(delFlag);
        }
        #endregion
    }
}
