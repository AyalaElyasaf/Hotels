using DAL.DalApi;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalImpalamation;

public class DalGeustService : IGuest
{
   
    HotelContext _HotelData;
    public DalGeustService(HotelContext HotelData)
    {
        _HotelData=HotelData;
    }
    public List<Guest> GetGuestList()
    {
        return _HotelData.Guests.ToList();
    }
    public bool AddGuest(Guest guest)
    {
        if (guest == null) return false;
        var g = _HotelData.Guests.FirstOrDefault(g=> g.Id==guest.Id);
        if (g!=null) return false;
        _HotelData.Guests.Add(guest);
        _HotelData.SaveChanges();
        return true;        
    }


}
