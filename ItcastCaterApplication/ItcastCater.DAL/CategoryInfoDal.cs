using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ItcastCater.Models;

namespace ItcastCater.DAL
{
    public class CategoryInfoDal
    {
        #region 根据商品分类删除标识获取所有商品分类
        /// <summary>
        /// 根据商品分类删除标识获取所有商品分类
        /// </summary>
        /// <param name="delFlag">删除标识</param>
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

        #region 关系转对象
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
        #endregion
    }
}
