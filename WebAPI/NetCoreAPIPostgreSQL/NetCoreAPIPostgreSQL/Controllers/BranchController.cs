using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.BranchRepository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : Controller
    {
        private readonly IBranchRepository _branchRespository;
        public BranchController(IBranchRepository branchRepository)
        {
            _branchRespository = branchRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllBranches()
        {
            return Ok(await _branchRespository.GetAllBranches());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBranchDetails(int id)
        {
            return Ok(await _branchRespository.GetBranchDetails(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateBranch([FromBody] Branch branch)
        {
            if (branch == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _branchRespository.InsertBranch(branch);
            return Created("Branch created", created);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBranch([FromBody] Branch branch)
        {
            if (branch == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            await _branchRespository.UpdateBranch(branch);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBranch(int id)
        {
            await _branchRespository.DeleteBranch(new Branch { Id_Branch = id });
            return NoContent();
        }
    }
}
