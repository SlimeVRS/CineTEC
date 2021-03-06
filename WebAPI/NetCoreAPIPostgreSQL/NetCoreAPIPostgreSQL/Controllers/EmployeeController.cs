using Microsoft.AspNetCore.Mvc;
using NetCoreAPIPostgreSQL.Data.Employee_Repository;
using NetCoreAPIPostgreSQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIPostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllClients()
        {
            return Ok(await _employeeRepository.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeDetails(int id)
        {
            return Ok(await _employeeRepository.GetEmployeeDetails(id));
        }

        [HttpGet("/api/[controller]/{user}/{password}")]
        public async Task<ActionResult> asdasd(string user, string password)
        {
            return Ok(await _employeeRepository.GetEmployeeByUserPassword(user, password));
        }
        [HttpGet("details")]
        public async Task<ActionResult> GetEmployeeDetailsWithNames()
        {
            return Ok(await _employeeRepository.GetEmployeeDetailsWithNames());
        }
                
        [HttpPost]
        public async Task<ActionResult> CreateEmployee([FromBody] EmployeeFRONTEND employee)
        {
            if (employee == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            var created = await _employeeRepository.InsertEmployeeFrontEnd(employee);
            return Created("employee created", created);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            await _employeeRepository.UpdateEmployee(employee);
            return NoContent();
        }
        [HttpPut("update")]
        public async Task<ActionResult> UpdateEmlpoyeeFromFrontEnd([FromBody] EmployeeFRONTEND employee)
        {
            if (employee == null)
                return BadRequest();
            if (!ModelState.IsValid)
                return BadRequest();
            await _employeeRepository.UpdateEmlpoyeeFromFrontEnd(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmploye(int id)
        {
            await _employeeRepository.DeleteEmployee(new Employee { Id_Employee = id });
            return NoContent();
        }
    }
}