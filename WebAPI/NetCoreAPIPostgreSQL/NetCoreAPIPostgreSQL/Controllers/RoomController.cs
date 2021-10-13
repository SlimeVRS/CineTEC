using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.Room_Repository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepositry;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepositry = roomRepository;
        }
        [HttpGet]
        public async Task<ActionResult>GetAllRooms()
        {
            return Ok(await _roomRepositry.GetAllRooms());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRoomDetails(int id)
        {
            return Ok(await _roomRepositry.GetRoomDetails(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateRoom([FromBody] Room room)
        {
            if (room == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _roomRepositry.InsertRoom(room);
            return Created("Room created", created);
        }

        [HttpPut]
        public async Task<ActionResult>UpdateRoom([FromBody] Room room)
        {
            if (room == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            await _roomRepositry.UpdateRoom(room);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task <ActionResult>DeleteRoom(int id)
        {
            await _roomRepositry.DeleteRoom(new Room { Id_Room = id });
            return NoContent();
        }
    }
}
