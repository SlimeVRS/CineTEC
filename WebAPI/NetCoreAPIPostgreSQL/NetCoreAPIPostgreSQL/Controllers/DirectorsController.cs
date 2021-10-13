using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.Directors_Repository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : Controller
    {
        private readonly IDirectorsRepository _directorsRepository;
        public DirectorsController(IDirectorsRepository directorsRepository)
        {
            _directorsRepository = directorsRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllDirectors()
        {
            return Ok(await _directorsRepository.GetAllDirectors());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult>GetDirectorDetails(int id)
        {
            return Ok(await _directorsRepository.GetDirectorDetails(id));
        }

        [HttpPost]
        public async Task<ActionResult>CreateDirector([FromBody] Director director)
        {
            if (director == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _directorsRepository.InsertDirector(director);
            return Created("Director created", created);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDirector([FromBody] Director director)
        {
            if (director == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            await _directorsRepository.UpdateDirector(director);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDirector(int id)
        {
            await _directorsRepository.DeleteDirector(new Director { Id_Director = id });
            return NoContent();
        }
    }
}
