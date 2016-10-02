using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItcastCater.DAL;
using ItcastCater.Models;

namespace ItcastCater.BLL
{
    public class RoomInfoService
    {
        RoomInfoDal roomDal = new RoomInfoDal();
        public List<RoomInfo> GetAllRoomInfoByDelFlag(int delFlag)
        {
            return roomDal.GetAllRoomInfoByDelFlag(delFlag);
        }
    }
}
