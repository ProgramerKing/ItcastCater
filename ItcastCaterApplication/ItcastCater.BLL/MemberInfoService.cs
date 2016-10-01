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

        #region 删除会员--逻辑删除
        /// <summary>
        /// 删除会员--逻辑删除
        /// 根据ID修改删除标识
        /// </summary>
        /// <param name="memberID">会员ID</param>
        /// <returns>受影响的行数</returns>
        public bool DelteMemberInfoByMemberID(int memberID)
        {
            return memDal.DeleteMemberInfoByMemberID(memberID) > 0;
        }
        #endregion
    }
}
