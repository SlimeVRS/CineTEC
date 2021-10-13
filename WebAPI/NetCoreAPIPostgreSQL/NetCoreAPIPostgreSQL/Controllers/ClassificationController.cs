using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.ClassificationRepository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassificationController : Controller
    {
        private readonly IClassificationRepository _classificationRepositiry;
        public ClassificationController(IClassificationRepository classificationRepository)
        {
            _classificationRepositiry = classificationRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllClassifications()
        {
            return Ok(await _classificationRepositiry.GetAllClassifications());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetClassificationDetails(int id)
        {
            return Ok(await _classificationRepositiry.GetClassificationDetails(id));
        }
        [HttpPost]
        public async Task<ActionResult>CreatedClassif([FromBody] Classification classification)
        {
            if (classification == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _classificationRepositiry.InsertClassification(classification);
            return Created("Classification created", created);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateClassif([FromBody] Classification classification)
        {
            if (classification == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            await _classificationRepositiry.UpdateClassification(classification);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClassif(int id)
        {
            await _classificationRepositiry.DeleteClassification(new Classification { Id_Classif = id });
            return NoContent();
        }
    }
}
