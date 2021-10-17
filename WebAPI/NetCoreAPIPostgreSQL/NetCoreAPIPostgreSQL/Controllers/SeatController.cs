using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.Seat_Repository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : Controller
    {
        private readonly ISeatRepository _seatRespository;
        public SeatController(ISeatRepository seatRepository)
        {
            _seatRespository = seatRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllSeats()
        {
            return Ok(await _seatRespository.GetAllSeats());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSeatDetails(int id)
        {
            return Ok(await _seatRespository.GetSeatDetails(id));
        }
        [HttpGet("room/{id}")]
        public async Task<ActionResult> GetSeatByRoomId(int id)
        {
            return Ok(await _seatRespository.GetSeatByRoomId(id));
        }
        [HttpPost]
        public async Task<ActionResult> CreateSeat([FromBody] Seat seat)
        {
            if(seat == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _seatRespository.InsertSeat(seat);
            return Created("Seat created", created);
        }
        [HttpPut("checkin")]
        public async Task<ActionResult> BuySeat([FromBody] Seat seat)
        {
            if (seat == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            var created = await _seatRespository.UpdateSeatByRoomIdandState(seat);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSeat([FromBody] Seat seat)
        {
            if (seat == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            await _seatRespository.UpdateSeat(seat);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSeat(int id)
        {
            await _seatRespository.DeleteSeat(new Seat { Id_Seat = id });
            return NoContent();
        }
    }
}
