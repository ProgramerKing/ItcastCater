/// <summary>
/// DAL
/// </summary>
namespace ItcastCater.DAL
{
    #region reference namespace
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using Models; 
    #endregion

    /// <summary>
    /// DAL CategoryInfoDAL
    /// </summary>
    public class CategoryInfoDAL
    {
        #region 新增商品类别
        /// <summary>
        /// 新增商品类别
        /// </summary>
        /// <param name="category">商品类别实体对象</param>
        /// <returns>受影响的行数</returns>
        public int AddCategoroyInfo(CategoryInfo category)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO CategoryInfo(CatName,CatNum,Remark,DelFlag,SubTime,SubBy) VALUES(@CatName,@CatNum,@Remark,@DelFlag,@SubTime,@SubBy)");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@CatName",SqlDbType.VarChar,32) {Value=category.CatName },
                new SqlParameter("@CatNum",SqlDbType.VarChar,32) {Value=category.CatNum },
                new SqlParameter("@Remark",SqlDbType.VarChar,64) {Value=category.Remark },
                new SqlParameter("@DelFlag",SqlDbType.SmallInt) {Value=category.SubBy },
                new SqlParameter("@SubTime",SqlDbType.Date) {Value=category.SubTime },
                new SqlParameter("@SubBy",SqlDbType.Int) {Value=category.SubBy }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, pms);
        }
        #endregion

        #region 根据商品类别的ID删除该类别
        /// <summary>
        /// 根据商品类别的ID删除该类别
        /// </summary>
        /// <param name="catID">商品类别ID</param>
        /// <returns>受影响的行数</returns>
        public int DeleteCategoryInfoByCatID(int catID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE CategoryInfo SET DelFlag=1 WHERE DelFlag=1");
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text);
        }
        #endregion

        #region 修改商品类别
        /// <summary>
        /// 修改商品类别
        /// </summary>
        /// <param name="category">商品类别实体对象</param>
        /// <returns>受影响的行数</returns>
        public int UpdateCategoryInfo(CategoryInfo category)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append( "UPDATE CategoryInfo SET CatName=@CatName,CatNum=@CatNum,Remark=@Remark WHERE CatID=@CatID");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@CatName",SqlDbType.VarChar,32) {Value=category.CatName },
                new SqlParameter("@CatNum",SqlDbType.VarChar,32) {Value=category.CatNum },
                new SqlParameter("@Remark",SqlDbType.VarChar,64) {Value=category.Remark },
                new SqlParameter("@CatID",SqlDbType.Int) {Value=category.CatID }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, pms);
        }
        #endregion

        #region 根据类别的ID查询类别对象
        /// <summary>
        /// 根据类别的ID查询类别对象
        /// </summary>
        /// <param name="catID">类别ID</param>
        /// <returns>model</returns>
        public CategoryInfo GetCategoryInfoByID(int catID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append( "SELECT * FROM CategoryInfo WHERE CatID=@CatID");
            CategoryInfo ct = null;
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@CatID", SqlDbType.Int) { Value = catID });
            if (dt.Rows.Count > 0)
            {
                ct = RowToCategoryInfo(dt.Rows[0]);
            }
            return ct;
        }
        #endregion

        #region 根据删除标识获取商品分类列表
        /// <summary>
        /// 根据删除标识获取商品分类列表
        /// </summary>
        /// <param name="delFlag">删除标识 0:未删除，1：已删除（逻辑删除）</param>
        /// <returns>list</returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            string sql = "SELECT CatID,CatName,CatNum,Remark FROM CategoryInfo WHERE DelFlag=@DelFlag";
            DataTable dt = SqlHelper.ExecuteTable(sql, CommandType.Text, new SqlParameter("@DelFlag", SqlDbType.Int) { Value = delFlag });
            List<CategoryInfo> list = new List<CategoryInfo>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToCategoryInfo(dr));
                }
            }
            return list;
        }
        #endregion

        #region 关系转对象
        /// <summary>
        /// 关系转对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>model</returns>
        private CategoryInfo RowToCategoryInfo(DataRow dr)
        {
            CategoryInfo category = new CategoryInfo();
            category.CatID = Convert.ToInt32(dr["CatID"]);
            category.CatName = dr["CatName"].ToString();
            category.CatNum = dr["CatNum"].ToString();
            category.Remark = dr["Remark"].ToString();
            return category;
        }
        #endregion
    }
}
