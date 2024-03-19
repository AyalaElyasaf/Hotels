using DAL.DalApi;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices;

public class DalHotelService : IHotel
{
    HotelContext _HotelData;
    public DalHotelService(HotelContext HotelData)
    {
        _HotelData = HotelData;
    }

    public List<Hotel> getHotelList()
    {
        return _HotelData.Hotels.ToList();
    }

    
}
