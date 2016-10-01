using ItcastCater.DAL;
using ItcastCater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItcastCater.BLL
{
    public class MemberTypeService
    {
        MemberTypeDal mtpDal = new MemberTypeDal();
        public List<MemberType> GetAllMemberTypeByDelFlag(int delFlag)
        {
            return mtpDal.GetAllMemberTypeByDelFlag(delFlag);
        }
    }
}
