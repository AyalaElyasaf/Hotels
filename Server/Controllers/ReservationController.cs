using BL.BLApi;
using BL.BO;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{

    IReservationBL _reservation;

    public ReservationController(BLManager BL)
    {
        _reservation = BL.reservations;
    }


    [HttpGet("all")]
    public List<BLReservation> GetReservationList()
    {
        return _reservation.GetReservationList();
    }

    [HttpGet("{ID}")]
    public List<BLReservation> GetReservationListByID(int id)
    {
        return _reservation.GetReservationListByID(id);
    }

    [HttpDelete("{ID}")]
    public bool removeReservation(int id)
    {
        return _reservation.removeReservation(id);
    }

    [HttpPost]
    public string AddReservation([FromBody] BLReservation r)
    {
        return _reservation.addReservation(r);
    }
}
