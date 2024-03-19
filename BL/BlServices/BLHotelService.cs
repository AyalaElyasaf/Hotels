using BL.BLApi;
using BL.BO;
using DAL;
using DAL.DalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BlServices;

public class BLHotelService : IHotelBL
{
    IHotel _hotels;

    public BLHotelService(DalManager dal)
    {
        _hotels = dal.Hotels;
    }

    public List<BLHotel> getHotelsList()
    {
        var hotels = _hotels.getHotelList();
        List<BLHotel> HotelsList = new List<BLHotel>();
        foreach (var h in hotels)
        {
            HotelsList.Add(new BLHotel()
            {
                Id = h.Id,
                HotelCantury = h.HotelCantury,
                HotelLocation = h.HotelLocation,
                HotelName = h.HotelName,
                HotelDescribe = h.HotelDescribe,
                HotelRating = h.HotelRating
            });
        }
        return HotelsList;
    }


    public List<BLHotel> getHoltelListByCantury(string cantury)
    {

        var hotels = _hotels.getHotelList().Where(h => h.HotelCantury.Trim().Equals(cantury));
        List<BLHotel> canturyHotels = new List<BLHotel>();
        foreach (var h in hotels)
        {
            canturyHotels.Add(new BLHotel()
            {
                Id = h.Id,
                HotelCantury = h.HotelCantury,
                HotelLocation = h.HotelLocation,
                HotelName = h.HotelName,
                HotelDescribe = h.HotelDescribe,
                HotelRating = h.HotelRating
            });

        }
        return canturyHotels;
    }


}
