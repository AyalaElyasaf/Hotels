using BL.BLApi;
using BL.BO;
using DAL;
using DAL.DalApi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlServices;

public class BLRoomService : IRoomBL
{

    IRoom _rooms;
    // IHotel _hotels;
    public BLRoomService(DalManager dal)
    {
        _rooms = dal.rooms;
        // _hotels = dal.Hotels;
    }

    public List<BLRoom> GetListRoomsForType(int id, string type)
    {

        List<BLRoom> roomsByType = new List<BLRoom>();
        BLRoom newRoom = new BLRoom();
        BLHotel h = new BLHotel();
        var temp = _rooms.getRoomList().Where(r => r.RoomType.Trim() == type && r.HotelId == id).ToList();
        temp.ForEach(r => roomsByType.Add(new BLRoom()
        {
            Id = r.Id,
            RoomNumber = r.RoomNumber,
            RoomPrice = r.RoomPrice,
            RoomCapacity = r.RoomCapacity,
            RoomType = r.RoomType,
            HotelId = r.HotelId,
            HotelDetails = new BLHotel() { Id = r.Hotel.Id, HotelName = r.Hotel.HotelName, HotelLocation = r.Hotel.HotelLocation, HotelDescribe = r.Hotel.HotelDescribe, HotelRating = r.Hotel.HotelRating }
        }));

        return roomsByType;
    }

}
