using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using ItcastCater.Models;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.DAL
{
    public class ProductInfoDal
    {
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
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text,new SqlParameter("@ProSpell", SqlDbType.VarChar, 64) { Value="%"+num+"%"});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据商品类别的id查询该类别下有没有产品
        /// </summary>
        /// <param name="CatID"></param>
        /// <returns></returns>
        public object GetProductInfoCountByCatID(int CatID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append( "SELECT COUNT(*) FROM ProductInfo WHERE DelFlag=0 AND CatID=@CatID");
            return SqlHelper.ExecuteScalar(sql.ToString(),CommandType.Text,new SqlParameter("@CatID", SqlDbType.Int) { Value=CatID});
        }
        /// <summary>
        /// 根据编号查找产品
        /// </summary>
        /// <param name="proNum"></param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByProNum(string proNum)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append( "SELECT * FROM ProductInfo WHERE DelFlag=0 AND ProNum LIKE @ProNum");
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(), CommandType.Text,new SqlParameter("@ProNum", SqlDbType.VarChar, 32) { Value="%"+proNum+"%"});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;

        }

        /// <summary>
        /// 根据的是商品类别的id查询该类别下所有的产品
        /// </summary>
        /// <param name="catID">类别的id</param>
        /// <returns></returns>
        public List<ProductInfo> GetProductInfoByCatID(int catID)
        {
            StringBuilder sql = new StringBuilder();
           sql.Append( "SELECT * FROM ProductInfo WHERE DelFlag=0 AND CatID=@CatID");
            List<ProductInfo> list = new List<ProductInfo>();
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(),CommandType.Text,new SqlParameter("@CatID", SqlDbType.Int) { Value=catID});
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(RowToProductInfo(dr));
                }
            }
            return list;
        }



        //新增
        //public int AddProductInfo(ProductInfo pro)
        //{
        //    string sql = "insert into ProductInfo(CatID,ProName,ProCost,ProSpell,ProPrice,ProUnit,Remark,DelFlag,SubTime,ProStock,ProNum,SubBy) values(@CatID,@ProName,@ProCost,@ProSpell,@ProPrice,@ProUnit,@Remark,@DelFlag,@SubTime,@ProStock,@ProNum,@SubBy)";
        //    return AddANDUpdate(pro, sql, 3);
        //}
        //修改
        //public int UpdateProductInfo(ProductInfo pro)
        //{
        //    string sql = "update ProductInfo set CatID=@CatID,ProName=@ProName,ProCost=@ProCost,ProSpell=@ProSpell,ProPrice=@ProPrice,ProUnit=@ProUnit,Remark=@Remark,ProStock=@ProStock,ProNum=@ProNum WHERE ProID=@ProID";
        //    return AddANDUpdate(pro, sql, 4);
        //}

        /// <summary>
        /// 根据id查询对象
        /// </summary>
        /// <param name="ProID"></param>
        /// <returns></returns>
        public ProductInfo GetProductInfoById(int ProID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append( "SELECT * FROM ProductInfo WHERE DelFlag=0 AND ProID=@ProID");
            DataTable dt = SqlHelper.ExecuteTable(sql.ToString(),CommandType.Text,new SqlParameter("@ProID", SqlDbType.Int) { Value = ProID });
            ProductInfo pro = null;
            if (dt.Rows.Count > 0)
            {
                pro = RowToProductInfo(dt.Rows[0]);
            }
            return pro;
        }
        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="ProID">id</param>
        /// <returns></returns>
        public int DeleteProductInfoByProID(int ProID)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE ProductInfo SET DelFlag=1 WHERE ProID=@ProID");
            return SqlHelper.ExecuteNonQuery(sql.ToString(),CommandType.Text,new SqlParameter("@ProID", SqlDbType.Int) { Value = ProID });
        }


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
