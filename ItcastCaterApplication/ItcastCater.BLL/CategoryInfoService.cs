/// <summary>
/// BLL
/// </summary>
namespace ItcastCater.BLL
{
    using System.Collections.Generic;
    using DAL;
    using Models;
    /// <summary>
    /// BLL CategoryInfoService
    /// </summary>
    public class CategoryInfoService
    {
        CategoryInfoDAL catDal = new CategoryInfoDAL();

        #region 根据删除标识获取商品分类列表
        /// <summary>
        /// 根据删除标识获取商品分类列表
        /// </summary>
        /// <param name="delFlag">删除标识，0：未删除，1：已删除</param>
        /// <returns>list</returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            return catDal.GetAllCategoryInfoByDelFlag(delFlag);
        }
        #endregion

        #region 根据商品类别的ID删除该类别
        /// <summary>
        /// 根据商品类别的ID删除该类别
        /// </summary>
        /// <param name="catID">商品类别ID</param>
        /// <returns>bool</returns>
        public bool DeleteCategoryInfoByCatID(int catID)
        {
            return catDal.DeleteCategoryInfoByCatID(catID) > 0;
        }
        #endregion

        #region 新增或修改商品类别
        /// <summary>
        /// 新增或修改商品类别
        /// </summary>
        /// <param name="ct">类别对象</param>
        /// <param name="temp">1:新增，2：修改</param>
        /// <returns>bool</returns>
        public bool SaveCategoryInfo(CategoryInfo ct,int temp)
        {
            int r = -1;
            if(temp==1)  //新增
            {
                r = catDal.AddCategoroyInfo(ct);
            }
            else if(temp==2) //修改
            {
                r = catDal.UpdateCategoryInfo(ct);
            }
            return r > 0;
        }
        #endregion

        #region 根据类别的ID查询类别对象
        /// <summary>
        /// 根据类别的ID查询类别对象
        /// </summary>
        /// <param name="catID">类别ID</param>
        /// <returns>CategoryInfo</returns>
        public CategoryInfo GetCategoryInfoByID(int catID)
        {
            return catDal.GetCategoryInfoByID(catID);
        }
        #endregion
    }
}
