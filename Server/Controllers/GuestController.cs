using DAL.DalApi;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BL.BLApi;
using BL;
using BL.BO;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GuestController : ControllerBase
{

    IGuestBL _geusts;

    public GuestController(BLManager BL)
    {
        _geusts = BL.guests;
    }


    [HttpGet]
    public List<BlSimpleGuest> GetGuestsList()
    {
        return _geusts.GetGuestList();
    }


    [HttpPost]
    public string AddGuest([FromBody]BlSimpleGuest guest)
    {
        return _geusts.addGuest(guest);
    }
}
