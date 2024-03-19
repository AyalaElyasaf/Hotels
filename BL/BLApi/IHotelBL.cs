using BL.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BLApi;

public interface IHotelBL
{
    public List<BLHotel> getHotelsList();
    public List<BLHotel> getHoltelListByCantury(string cantury);
}
