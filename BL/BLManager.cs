using BL.BLApi;
using BL.BLImplamation;
using BL.BlServices;
using DAL;
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

namespace BL;

public class BLManager
{
    public IGuestBL guests { get; }
    public IHotelBL hotels { get; }
    public IRoomBL rooms { get; }
    public IReservationBL reservations { get; }

    public BLManager()
    {
        
        ServiceCollection services = new ServiceCollection();
      
        services.AddSingleton<DalManager>();
        services.AddScoped<IGuestBL, BlGuestService>();
        services.AddScoped<IHotelBL, BLHotelService>();
        services.AddScoped<IRoomBL, BLRoomService>();
        services.AddScoped<IReservationBL, BLReservationService>();

        ServiceProvider Provider = services.BuildServiceProvider();
        guests = Provider.GetService<IGuestBL>();
        hotels = Provider.GetService<IHotelBL>();
        rooms = Provider.GetService<IRoomBL>();
        reservations = Provider.GetService<IReservationBL>();
       
    }
}