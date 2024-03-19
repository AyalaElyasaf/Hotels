using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO;

public class BLHotel
{
    public int Id { get; set; }

    public string HotelName { get; set; } = null!;

    public string HotelLocation { get; set; } = null!;

    public int HotelRating { get; set; }

    public string HotelDescribe { get; set; } = null!;

    public string HotelCantury { get; set; } = null!;
}
