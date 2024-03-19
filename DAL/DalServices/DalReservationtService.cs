using DAL.DalApi;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalServices;

public class DalReservationtService: IReservation
{
    HotelContext _HotelData;
    public DalReservationtService(HotelContext HotelData)
    {
        _HotelData = HotelData;
    }
    public List<Reservation> getReservationList()
    {
        var s= _HotelData.Reservations
            .Include(r=>r.Guest)
            .Include(r=>r.Room)
            .ThenInclude(Room=>Room.Hotel)
            .ToList();
        return s;
    }
    public List<Reservation> getReservationListByID(int id)
    {
        var s = _HotelData.Reservations
            .Where(h=>h.Id==id)
            .Include(r => r.Guest)
            .Include(r => r.Room)
            .ThenInclude(Room => Room.Hotel)
            .ToList();
        return s;
    }
    public bool removeReservationt(int id)
    {
        //if (reservation == null)  return false;
        var r = _HotelData.Reservations.FirstOrDefault(r => r.Id == id);
        _HotelData.Reservations.Remove(r);
        _HotelData.SaveChanges();
        return true;
    }

    public bool updateReservation(Reservation reservation)
    {
        if(reservation == null) return false;
        var r = _HotelData.Reservations.FirstOrDefault(r => r.Id == reservation.Id);
        
        r.Id = reservation.Id;
        r.RoomId = reservation.RoomId;
        r.CheckIn = reservation.CheckIn;
        r.CheckOut = reservation.CheckOut;
        r.GuestId = reservation.GuestId;
        _HotelData.SaveChanges();
        return true;
    }

    public bool addReservation(Reservation reservation)
    {
        if (reservation == null) return false;
        var r = _HotelData.Reservations.FirstOrDefault(r=>r.RoomId==reservation.Id);
        if (r != null) return false;
        _HotelData.Reservations.Add(reservation);
        _HotelData.SaveChanges();
        return true;
    }


}
