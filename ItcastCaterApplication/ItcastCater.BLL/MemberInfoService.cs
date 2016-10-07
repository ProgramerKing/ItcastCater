/// <summary>
/// BLL
/// </summary>
namespace ItcastCater.BLL
{
    using DAL;
    using Models;
    using System.Collections.Generic;
    /// <summary>
    /// BLL MemberInfoServie
    /// </summary>
    public class MemberInfoService
    {
        MemberInfoDAL memDal = new MemberInfoDAL();

        #region 根据删除标识获取会员列表
        /// <summary>
        /// 根据删除标识获取会员列表
        /// </summary>
        /// <param name="delFlag">删除标识，0：未删除，1：已删除</param>
        /// <returns>list</returns>
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
        /// <returns>true：删除成功，false：删除失败</returns>
        public bool DelteMemberInfoByMemberID(int memberID)
        {
            return memDal.DeleteMemberInfoByMemberID(memberID) > 0;
        }
        #endregion

        #region 根据ID查询对象
        /// <summary>
        /// 根据ID查询对象
        /// </summary>
        /// <param name="memberID">会员ID</param>
        /// <returns>MemberInfo</returns>
        public MemberInfo GetMemberInfoByMemberID(int memberID)
        {
            return memDal.GetMemberInfoByMemberID(memberID);
        }
        #endregion

        #region 新增或是修改会员
        /// <summary>
        /// 新增或是修改会员
        /// </summary>
        /// <param name="mem">会员对象</param>
        /// <param name="temp">1:新增，2:修改</param>
        /// <returns>true:成功，false：失败</returns>
        public bool SaveMemberInfo(MemberInfo mem,int temp)
        {
            int r = -1;
            if(temp==1)
            {
                r = memDal.AddMemmberInfo(mem);
            }
            else if(temp==2)
            {
                r = memDal.UpdateMemmberInfo(mem);
            }
            return r > 0;
        }
        #endregion
    }
}
