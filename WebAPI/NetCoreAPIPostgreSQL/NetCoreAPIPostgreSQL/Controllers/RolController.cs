using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.RolRepository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : Controller
    {
        private readonly IRolRepository _rolRepository;
        public RolController(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllRoles()
        {
            return Ok(await _rolRepository.GetAllRoles());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRolDetails(int id)
        {
            return Ok(await _rolRepository.GetRolDetails(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateRol([FromBody] Rol rol)
        {
            if (rol == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _rolRepository.InsertRol(rol);
            return Created("Rol created", created);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateRol([FromBody] Rol rol)
        {
            if (rol == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            await _rolRepository.UpdateRol(rol);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRol(int id)
        {
            await _rolRepository.DeleteRol(new Rol { Id = id });
            return NoContent();
        }
    }
}
