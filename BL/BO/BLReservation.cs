using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO;

public class BLReservation
{
    public int Id { get; set; }

    public int GuestId { get; set; }
    public BlSimpleGuest GuestDetials { get; set; }

    public int RoomId { get; set; }
    public BLRoom RoomDetials { get; set; }
    public BLHotel HotelDetials { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }
    public int NumOfDays { get; set;}

}
