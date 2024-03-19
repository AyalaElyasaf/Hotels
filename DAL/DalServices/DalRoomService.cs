using DAL.DalApi;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices;

public class DalRoomService:IRoom
{

    HotelContext _HotelData;
    public DalRoomService(HotelContext HotelData)
    {
        _HotelData = HotelData;
    }
    public List<Room> getRoomList()
    {
        return _HotelData.Rooms
            .Include(h=>h.Hotel)
            .ToList();
    }
}
