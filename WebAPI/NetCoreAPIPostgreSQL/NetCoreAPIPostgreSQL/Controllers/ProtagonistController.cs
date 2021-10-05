using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.Protagonist_Repository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtagonistController : Controller
    {
        private readonly IProtagonistRepository _protagonistRepository;
        public ProtagonistController(IProtagonistRepository protagonistRepository)
        {
            _protagonistRepository = protagonistRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllProtagonists()
        {
            return Ok(await _protagonistRepository.GetAllProtagonists());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProtagonistDetails(int id)
        {
            return Ok(await _protagonistRepository.GetProtagonistDetails(id));
        }
        [HttpPost]
        public async Task<ActionResult> CreateProtagonist([FromBody] Protagonist protagonist)
        {
            if (protagonist == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _protagonistRepository.InsertProtagonist(protagonist);
            return Created("Director created", created);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateProtagonist([FromBody] Protagonist protagonist)
        {
            if (protagonist == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            await _protagonistRepository.UpdateProtagonist(protagonist);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProtagonist(int id)
        {
            await _protagonistRepository.DeleteProtagonist(new Protagonist { Id = id });
            return NoContent();
        }
    }
}
