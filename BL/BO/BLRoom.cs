using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO;

public class BLRoom
{
    public int Id { get; set; }

    public int HotelId { get; set; }
    public BLHotel HotelDetails { get; set; }
    public int RoomNumber { get; set; }

    public string RoomType { get; set; } = null!;

    public int RoomPrice { get; set; }

    public int RoomCapacity { get; set; }

}
