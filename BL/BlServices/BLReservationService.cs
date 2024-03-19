using BL.BLApi;
using DAL.DalApi;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BO;
using DAL.Models;

namespace BL.BlServices;

public class BLReservationService : IReservationBL
{
    IReservation _reservation;

    public BLReservationService(DalManager dal)
    {
        _reservation = dal.reservations;
    }

    public List<BLReservation> GetReservationList()
    {
        var list = _reservation.getReservationList();

        List<BLReservation> reservationlist = new List<BLReservation>();
        BlSimpleGuest guest = new BlSimpleGuest();
        BLRoom room = new BLRoom();
        BLHotel hotel = new BLHotel();

        foreach (var g in list)
        {
            //אתחול האורח
            guest.Id = g.Guest.Id;
            guest.Name = g.Guest.GuestName;
            guest.GuestEmail = g.Guest.GuestEmail;
            guest.GuestPhone = g.Guest.GuestPhone;

            //אתחול המלון
            hotel.HotelName = g.Room.Hotel.HotelName;
            hotel.Id = g.Room.Hotel.Id;
            hotel.HotelLocation = g.Room.Hotel.HotelLocation;
            hotel.HotelDescribe = g.Room.Hotel.HotelDescribe;
            hotel.HotelRating = g.Room.Hotel.HotelRating;

            //אתחול החדר
            room.Id = g.Room.Id;
            room.RoomNumber = g.Room.RoomNumber;
            room.RoomType = g.Room.RoomType;
            room.RoomCapacity = g.Room.RoomCapacity;
            room.RoomPrice = g.Room.RoomPrice;

            //אתחול ההזמנה
            var newguest = new BLReservation()
            {
                Id = g.Id,
                CheckIn = g.CheckIn,
                CheckOut = g.CheckOut,
                NumOfDays = g.CheckOut.Day - g.CheckIn.Day % 30,
                GuestDetials = guest,
                HotelDetials = hotel,
                RoomDetials = room
            };

            reservationlist.Add(newguest);
        }
        return reservationlist;
    }

    public List<BLReservation> GetReservationListByID(int id)
    {
        var list = _reservation.getReservationListByID(id);

        List<BLReservation> reservationlist = new List<BLReservation>();
        BlSimpleGuest guest = new BlSimpleGuest();
        BLRoom room = new BLRoom();
        BLHotel hotel = new BLHotel();

        foreach (var g in list)
        {
            //אתחול האורח
            guest.Id = g.Guest.Id;
            guest.Name = g.Guest.GuestName;
            guest.GuestEmail = g.Guest.GuestEmail;
            guest.GuestPhone = g.Guest.GuestPhone;

            //אתחול המלון
            hotel.HotelName = g.Room.Hotel.HotelName;
            hotel.Id = g.Room.Hotel.Id;
            hotel.HotelLocation = g.Room.Hotel.HotelLocation;
            hotel.HotelDescribe = g.Room.Hotel.HotelDescribe;
            hotel.HotelRating = g.Room.Hotel.HotelRating;

            //אתחול החדר
            room.Id = g.Room.Id;
            room.RoomNumber = g.Room.RoomNumber;
            room.RoomType = g.Room.RoomType;
            room.RoomCapacity = g.Room.RoomCapacity;
            room.RoomPrice = g.Room.RoomPrice;

            //אתחול ההזמנה
            var newguest = new BLReservation()
            {
                Id = g.Id,
                CheckIn = g.CheckIn,
                CheckOut = g.CheckOut,
                NumOfDays = g.CheckOut.Day - g.CheckIn.Day % 30,
                GuestDetials = guest,
                HotelDetials = hotel,
                RoomDetials = room
            };

            reservationlist.Add(newguest);
        }
        return reservationlist;
    }

    public bool removeReservation(int id)
    {
        return _reservation.removeReservationt(id);
    }


    public string addReservation(BLReservation reservation)
    {
        Reservation r = new Reservation() { Id = reservation.Id ,RoomId=reservation.RoomId, GuestId=reservation.GuestId, CheckIn=reservation.CheckIn,CheckOut=reservation.CheckOut};
        var reservations = _reservation.getReservationList();
        if (reservations.Contains(r)) return "The user already exists";
        bool b = _reservation.addReservation(r);
        if (b)
            return "You have successfully registered!";
        return "Registration failed";
    }
}
