using DAL.DalApi;
using DAL.DalImpalamation;
using DAL.DalServices;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // לבצע הזרקות
    // ליצג את שכבת הדל בצורה מרוכזת
    public class DalManager
    {
        public IGuest Guests { get;  }
        public IHotel  Hotels { get; }
        public IReservation reservations { get; }
        public IRoom rooms { get; }
        public DalManager()
        {
            // אוביקט שיכיל את כל מחלקות השרות
            ServiceCollection services = new ServiceCollection();
            // מוסיפים לאוסף את אוביקט ממחלקות השרות
            services.AddDbContext<HotelContext>();
            services.AddScoped<IGuest, DalGeustService>();
            services.AddScoped<IHotel, DalHotelService>();
            services.AddScoped<IReservation, DalReservationtService>();
            services.AddScoped<IRoom, DalRoomService>();

            ServiceProvider Provider = services.BuildServiceProvider();
            Guests = Provider.GetService<IGuest>();
            Hotels = Provider.GetService<IHotel>();
            reservations= Provider.GetService<IReservation>();
            rooms= Provider.GetService<IRoom>();
        }
    }
}
