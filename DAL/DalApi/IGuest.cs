using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DalApi;

public interface IGuest
{
    public List<Guest> GetGuestList();
    public bool AddGuest(Guest guest);
}
