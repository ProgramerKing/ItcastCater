using ItcastCater.DAL;
using ItcastCater.Models;
using System.Collections.Generic;

namespace ItcastCater.BLL
{
    public class MemberInfoService
    {
        MemberInfoDal memDal = new MemberInfoDal();
        #region 根据删除标识获取用户列表
        /// <summary>
        /// 根据删除标识获取用户列表
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns></returns>
        public List<MemberInfo> GetAllMemberInfoByDelFlag(int delFlag)
        {
            return memDal.GetAllMemberInfoByDelFlag(delFlag);
        } 
        #endregion
    }
}
