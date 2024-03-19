using BL.BLApi;
using BL.BO;
using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoomController : ControllerBase
{
    IRoomBL _rooms;

    public RoomController(BLManager BL)
    {
        _rooms = BL.rooms;
    }


    [HttpGet]
    public List<BLRoom> GetRoomListByType([FromQuery]int id, [FromQuery] string type)
    {
        return _rooms.GetListRoomsForType(id, type);
    }

}
