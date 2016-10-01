using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.DAL;
using ItcastCater.Models;

namespace ItcastCater.BLL
{
    public class CategoryInfoService
    {
        CategoryInfoDal catDal = new CategoryInfoDal();
        #region 根据删除标识获取所有商品分类
        /// <summary>
        /// 根据删除标识获取所有商品分类
        /// </summary>
        /// <param name="delFlag">删除标识</param>
        /// <returns>list</returns>
        public List<CategoryInfo> GetAllCategoryInfoByDelFlag(int delFlag)
        {
            return catDal.GetAllCategoryInfoByDelFlag(delFlag);
        } 
        #endregion
    }
}
