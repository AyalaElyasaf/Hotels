using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Hotel
{
    public int Id { get; set; }

    public string HotelName { get; set; } = null!;

    public string HotelLocation { get; set; } = null!;

    public int HotelRating { get; set; }

    public string HotelDescribe { get; set; } = null!;

    public string HotelCantury { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
