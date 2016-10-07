/// <summary>
/// DAL
/// </summary>
namespace ItcastCater.DAL
{
    #region reference namespace
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using Models;
    using System.Text; 
    #endregion

    /// <summary>
    /// DAL ProductInfoDAL
    /// </summary>
    public class ProductInfoDAL
    {
        #region 根据拼音或者编号查询产品
        /// <summary>
        /// 根据拼音或者编号查询产品
        /// </summary>
        /// <param name="num">可以是拼音，可以是编号</param>
        /// <param name="temp">1---拼音，2---编号</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoBySpellOrNum(string num, int temp)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM ProductInfo WHERE DelFlag=0");
            if (temp == 1)//拼音
            {
                sql.Append(" AND ProSpell LIKE @ProSpell");
            }
            else if (temp == 2)
            {
                sql.Append(" AND ProNum LIKE @ProSpell");
            }
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@ProSpell", SqlDbType.VarChar, 64) { Value = "%" + num + "%" });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        } 
        #endregion

        #region 根据商品类别的ID查询该类别下有没有产品
        /// <summary>
        /// 根据商品类别的ID查询该类别下有没有产品
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        public object GetProductInfoCountByCatID(int CatID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT COUNT(*) FROM ProductInfo WHERE DelFlag=0 AND CatID=@CatID");
            return SqlHelper.ExecuteScalar(sql.ToString(), CommandType.Text, new SqlParameter("@CatID", SqlDbType.Int) { Value = CatID });
        } 
        #endregion

        #region 根据编号查找产品
        /// <summary>
        /// 根据编号查找产品
        /// </summary>
        /// <param name="proNum">产品编号</param>
        /// <returns>list</returns>
        public List<ProductInfo> GetProductInfoByProNum(string proNum)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM ProductInfo WHERE DelFlag=0 AND ProNum LIKE @ProNum");
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@ProNum", SqlDbType.VarChar, 32) { Value = "%" + proNum + "%" });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;

        } 
        #endregion

        #region 根据的是商品类别的ID查询该类别下所有的产品
        /// <summary>
        /// 根据的是商品类别的ID查询该类别下所有的产品
        /// </summary>
        /// <param name="catID">类别的ID</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatID(int catID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM ProductInfo WHERE DelFlag=0 AND CatID=@CatID");
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@CatID", SqlDbType.Int) { Value = catID });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        } 
        #endregion

        #region 新增产品
        /// <summary>
        /// 新增产品
        /// </summary>
        /// <param name="pro">ProductInfo实体</param>
        /// <returns>受影响的行数</returns>
        public int AddProductInfo(ProductInfo pro)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO ProductInfo(CatID,ProName,ProCost,ProSpell,ProPrice,ProUnit,Remark,DelFlag,SubTime,ProStock,ProNum,SubBy) values(@CatID,@ProName,@ProCost,@ProSpell,@ProPrice,@ProUnit,@Remark,@DelFlag,@SubTime,@ProStock,@ProNum,@SubBy)");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@CatID",SqlDbType.Int) {Value=pro.CatID },
                new SqlParameter("@ProName",SqlDbType.VarChar,32) {Value=pro.ProName },
                new SqlParameter("@ProCost",SqlDbType.Decimal,18) {Value=pro.ProCost },
                new SqlParameter("@ProSpell",SqlDbType.VarChar,64) {Value=pro.ProSpell },
                new SqlParameter("@ProPrice",SqlDbType.Decimal,18) {Value=pro.ProPrice },
                new SqlParameter("@ProUnit",SqlDbType.VarChar,16) {Value=pro.ProUnit },
                new SqlParameter("@Remark",SqlDbType.VarChar,64) {Value=pro.Remark },
                new SqlParameter("@DelFlag",SqlDbType.SmallInt) {Value=pro.DelFlag },
                new SqlParameter("@SubTime",SqlDbType.Date) {Value= pro.SubTime},
                new SqlParameter("@ProStock",SqlDbType.Decimal,18) {Value=pro.ProStock },
                new SqlParameter("@ProNum",SqlDbType.VarChar,32) {Value=pro.ProNum },
                new SqlParameter("@SubBy",SqlDbType.Int) {Value=pro.SubBy }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, pms);
        } 
        #endregion

        #region 修改产品信息
        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="pro">ProductInfo实体</param>
        /// <returns>受影响的行数</returns>
        public int UpdateProductInfo(ProductInfo pro)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE ProductInfo SET CatID=@CatID,ProName=@ProName,ProCost=@ProCost,ProSpell=@ProSpell,ProPrice=@ProPrice,ProUnit=@ProUnit,Remark=@Remark,ProStock=@ProStock,ProNum=@ProNum WHERE ProID=@ProID");
            SqlParameter[] pms = new SqlParameter[]
            {
                new SqlParameter("@CatID",SqlDbType.Int) {Value=pro.CatID },
                new SqlParameter("@ProName",SqlDbType.VarChar,32) {Value=pro.ProName },
                new SqlParameter("@ProCost",SqlDbType.Decimal,18) {Value=pro.ProCost },
                new SqlParameter("@ProSpell",SqlDbType.VarChar,64) {Value=pro.ProSpell },
                new SqlParameter("@ProPrice",SqlDbType.Decimal,18) {Value=pro.ProPrice },
                new SqlParameter("@ProUnit",SqlDbType.VarChar,16) {Value=pro.ProUnit },
                new SqlParameter("@Remark",SqlDbType.VarChar,64) {Value=pro.Remark },
                new SqlParameter("@SubTime",SqlDbType.Date) {Value= pro.SubTime},
                new SqlParameter("@ProStock",SqlDbType.Decimal,18) {Value=pro.ProStock },
                new SqlParameter("@ProNum",SqlDbType.VarChar,32) {Value=pro.ProNum },
                new SqlParameter("@ProID",SqlDbType.Int) {Value=pro.ProID }
            };
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, pms);

        }
        #endregion

        #region 根据ID查询对象
        /// <summary>
        /// 根据ID查询对象
        /// </summary>
        /// <param name="proID">产品ID</param>
        /// <returns>实体对象</returns>
        public ProductInfo GetProductInfoByProID(int proID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM ProductInfo WHERE DelFlag=0 AND ProID=@ProID");
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@ProID", SqlDbType.Int) { Value = proID });
            ProductInfo pro = null;
            if (dt.Rows.Count > 0)
            {
                pro = RowToProductInfo(dt.Rows[0]);
            }
            return pro;
        }
        #endregion

        #region 根据ID删除产品
        /// <summary>
        /// 根据ID删除产品
        /// </summary>
        /// <param name="proID">产品ID</param>
        /// <returns></returns>
        public int DeleteProductInfoByProID(int proID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE ProductInfo SET DelFlag=1 WHERE ProID=@ProID");
            return SqlHelper.ExecuteNonQuery(sql.ToString(), CommandType.Text, new SqlParameter("@ProID", SqlDbType.Int) { Value = proID });
        } 
        #endregion

        #region 根据删除标识查询所有产品
        /// <summary>
        /// 根据删除标识查询所有产品
        /// </summary>
        /// <param name="delFlag">删除标识 0:未删除，1：已删除（逻辑删除）</param>
        /// <returns>list</returns>
        public List<ProductInfo> GetAllProductInfoByDelFlag(int delFlag)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ProID, CatID, ProName, ProCost, ProSpell, ProPrice, ProUnit, Remark, ProStock, ProNum FROM ProductInfo WHERE DelFlag =@DelFlag");

            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text, new SqlParameter("@DelFlag", SqlDbType.SmallInt) { Value = delFlag });
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
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
        private ProductInfo RowToProductInfo(DataRow dr)
        {
            ProductInfo pro = new ProductInfo();
            pro.CatID = Convert.ToInt32(dr["CatID"]);
            // pro.DelFlag = Convert.ToInt32(dr["DelFlag"]);
            pro.ProCost = Convert.ToDecimal(dr["ProCost"]);
            pro.ProID = Convert.ToInt32(dr["ProID"]);
            pro.ProName = dr["ProName"].ToString();
            pro.ProNum = dr["ProNum"].ToString();
            pro.ProPrice = Convert.ToDecimal(dr["ProPrice"]);
            pro.ProSpell = dr["ProSpell"].ToString();
            pro.ProStock = Convert.ToDecimal(dr["ProStock"]);
            pro.ProUnit = dr["ProUnit"].ToString();
            pro.Remark = dr["Remark"].ToString();
            // pro.SubBy = Convert.ToInt32(dr["SubBy"]);
            // pro.SubTime = Convert.ToDateTime(dr["SubTime"]);
            return pro;
        } 
        #endregion
    }
}
