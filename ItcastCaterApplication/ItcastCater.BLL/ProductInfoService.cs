/// <summary>
/// BLL
/// </summary>
namespace ItcastCater.BLL
{
    using System;
    using System.Collections.Generic;
    using DAL;
    using Models;
    /// <summary>
    /// BLL ProductInfoService
    /// </summary>
    public class ProductInfoService
    {
        ProductInfoDAL productDal = new ProductInfoDAL();

        #region 根据商品类别的ID查询该类别下有没有产品
        /// <summary>
        /// 根据商品类别的ID查询该类别下有没有产品
        /// </summary>
        /// <param name="catID">商品类别ID</param>
        /// <returns></returns>
        public int GetProductInfoCountByCatID(int catID)
        {
            return Convert.ToInt32(productDal.GetProductInfoCountByCatID(catID));//坑
        } 
        #endregion

        #region 根据产品编号查找产品
        /// <summary>
        /// 根据产品编号查找产品
        /// </summary>
        /// <param name="proNum">产品编号</param>
        /// <returns>list</returns>
        public List<ProductInfo> GetProductInfoByProNum(string proNum)
        {
            return productDal.GetProductInfoByProNum(proNum);
        } 
        #endregion

        #region 根据的是商品类别的ID查询该类别下所有的产品
        /// <summary>
        /// 根据的是商品类别的ID查询该类别下所有的产品
        /// </summary>
        /// <param name="catID">类别的ID</param>
        /// <returns>list</returns>
        public List<ProductInfo> GetProductInfoByCatID(int catID)
        {
            return productDal.GetProductInfoByCatID(catID);
        } 
        #endregion

        #region 增加或者是修改产品
        /// <summary>
        /// 增加或者是修改产品
        /// </summary>
        /// <param name="pro">产品对象</param>
        /// <param name="temp">3---新增,4----修改</param>
        /// <returns>true:操作成功，false：操作失败</returns>
        public bool SaveProduct(ProductInfo pro, int temp)
        {
            int r = 0;
            if (temp == 3)//新增
            {
                r = productDal.AddProductInfo(pro);
            }
            else if (temp == 4)//修改
            {
                r = productDal.UpdateProductInfo(pro);
            }
            return r > 0;

        } 
        #endregion

        #region 根据ID查询对象
        /// <summary>
        /// 根据ID查询对象
        /// </summary>
        /// <param name="proID">产品ID</param>
        /// <returns>ProductInfo</returns>
        public ProductInfo GetProductInfoByProID(int proID)
        {
            return productDal.GetProductInfoByProID(proID);
        } 
        #endregion

        #region 删除产品--逻辑删除
        /// <summary>
        /// 删除产品--逻辑删除
        /// 修改产品的删除标识为
        /// </summary>
        /// <param name="proID">产品ID</param>
        /// <returns>true:删除成功，false：删除失败</returns>
        public bool DeleteProductInfoByProID(int proID)
        {
            return productDal.DeleteProductInfoByProID(proID) > 0;
        }
        #endregion

        #region 根据删除标识获取产品列表
        /// <summary>
        /// 根据删除标识获取产品列表
        /// </summary>
        /// <param name="delFlag">删除标识，0：未删除，1：已删除</param>
        /// <returns>list</returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            return productDal.GetAllProductInfoByDelFlag(delFlag);
        } 
        #endregion
    }
}
