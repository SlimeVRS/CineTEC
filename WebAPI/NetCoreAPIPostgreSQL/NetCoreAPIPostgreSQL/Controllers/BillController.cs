using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.Bill_Repository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : Controller
    {
        private readonly IBillRepository _billRespository;
        public BillController(IBillRepository billRepository)
        {
            _billRespository = billRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllBills()
        {
            return Ok(await _billRespository.GetAllBills());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetBillDetails(int id)
        {
            return Ok(await _billRespository.GetBillDetails(id));
        }
        [HttpPost]
        public async Task<ActionResult> CreateBill([FromBody] Bill bill)
        {
            if (bill == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _billRespository.InsertBill(bill);
            return Created("Bill created", created);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateBill([FromBody] Bill bill)
        {
            if (bill == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            await _billRespository.UpdateBill(bill);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBill(int id)
        {
            await _billRespository.DeleteBill(new Bill { Id_Bill = id });
            return NoContent();
        }
    }
}
