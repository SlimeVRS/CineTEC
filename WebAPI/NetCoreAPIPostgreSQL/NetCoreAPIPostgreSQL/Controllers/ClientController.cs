using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.Client_Repository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllClients()
        {
            return Ok(await _clientRepository.GetAllClients());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetClientDetails(int id)
        {
            return Ok(await _clientRepository.GetClientDetails(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateClient([FromBody] Client client)
        {
            if (client == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            var created = await _clientRepository.InsertClient(client);
            return Created("Client created", created);
        }
        [HttpPut]
        public async Task<ActionResult> UpdateClient([FromBody] Client client)
        {
            if (client == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();

            await _clientRepository.UpdateClient(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            await _clientRepository.DeleteClient(new Client { Id_Client = id });
            return NoContent();
        }
    }
}
