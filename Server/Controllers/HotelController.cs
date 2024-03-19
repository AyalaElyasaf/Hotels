using BL.BLApi;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.BO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HotelController : ControllerBase
{
    IHotelBL _hotels;

    public HotelController(BLManager BL)
    {
        _hotels = BL.hotels;
    }


    [HttpGet("all")]
    public List<BLHotel> GetHotelList()
    {
        return _hotels.getHotelsList();
    }

    [HttpGet]
    public List<BLHotel> GetHotelsByCantury([FromQuery] string cantury)
    {
        return _hotels.getHoltelListByCantury(cantury);
    }

}
