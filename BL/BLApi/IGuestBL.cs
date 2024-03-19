using BL.BO;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi;

public interface IGuestBL
{
    public List<BlSimpleGuest> GetGuestList();

    public string addGuest(BlSimpleGuest guest);
}
