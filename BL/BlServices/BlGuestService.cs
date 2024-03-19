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

namespace BL.BLImplamation;

public class BlGuestService : IGuestBL
{
    IGuest _geusts;

    public BlGuestService(DalManager dal)
    {
        _geusts = dal.Guests;
    }


    public List<BlSimpleGuest> GetGuestList()
    {
        var list = _geusts.GetGuestList();

        List<BlSimpleGuest> guestlist = new List<BlSimpleGuest>();

        foreach (var g in list)
        {
            var newguest = new BlSimpleGuest()
            {
                Id = g.Id,
                Name = g.GuestName,
                GuestEmail = g.GuestEmail
            };

            guestlist.Add(newguest);
        }
        return guestlist;
    }

    public string addGuest(BlSimpleGuest guest)
    {
        Guest g = new Guest() { Id = guest.Id, GuestName = guest.Name, GuestEmail = guest.GuestEmail, GuestPhone = guest.GuestPhone };
        var s = _geusts.GetGuestList();
        if (s.Contains(g)) return "The user already exists";
        bool b = _geusts.AddGuest(g);
        if (b)
            return "You have successfully registered!";
        return "Registration failed";
    }








}
