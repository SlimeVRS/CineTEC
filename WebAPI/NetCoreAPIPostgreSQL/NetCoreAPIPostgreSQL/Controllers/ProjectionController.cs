using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.Projection_Repository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionController : Controller
    {
        private readonly IProjectionRepository _projectionRespository;
        public ProjectionController(IProjectionRepository projectionRespository)
        {
            _projectionRespository = projectionRespository;
        }
        [HttpGet]
        public async Task <ActionResult>GetAllProjections()
        {
            return Ok(await _projectionRespository.GetAllProjections());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetProjectionDetails(int id)
        {
            return Ok(await _projectionRespository.GetProjectionDetails(id));
        }
        [HttpGet("all")]
        public async Task<ActionResult> GetDetailedProjections()
        {
            return Ok(await _projectionRespository.GetDetailedProjections());
        }
        [HttpPost]
        public async Task<ActionResult> CreateProjection([FromBody] ProjectionFRONTEND projection)
        {
            if (projection == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _projectionRespository.InsertProjectionFrontEnd(projection);
            return Created("Projection created", created);
        }
        [HttpPut("update")]
        public async Task<ActionResult> UpdateInsertionByMovieName([FromBody] ProjectionFRONTEND projection)
        {
            if (projection == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            await _projectionRespository.UpdateInsertionByMovieName(projection);
            return NoContent();
        }
        [HttpPut]
        public async Task<ActionResult> UpdateProjection([FromBody] Projection projection)
        {
            if (projection == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            await _projectionRespository.UpdateProjection(projection);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProjection(int id)
        {
            await _projectionRespository.DeleteProjection(new Projection { Id_Projection = id });
            return NoContent();
        }
    }
}
