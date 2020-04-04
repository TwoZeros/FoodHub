using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkerCRM.Data;
using WorkerCRM.Models;
using WorkerCRM.Dto.Models;
using WorkerCRM.Services.Contract;
using WorkerCRM.Services.Contract.Dto;
using Microsoft.AspNetCore.Authorization;

namespace WorkerCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly WorkerCRMDbContext _context;
        private readonly IClientService _clientService;
        public ClientController(WorkerCRMDbContext context, IClientService clientService)
        {
            _context = context;
            _clientService = clientService;
        }

        // GET: api/Employees
        [HttpGet]
        public List<ClientListDto> GetEmployees()
        {
   
        return _clientService.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee(int id)
        {
            var employee = await _clientService.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return new JsonResult(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Client client)
        {
            if (id != client.Id)
                return BadRequest();

            _clientService.PutClient(id, client);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("{id}/upload-avatar")]
        public async Task<IActionResult> PutEmployeePhoto(int id, Client client)
        {
            if (id != client.Id)
                return BadRequest();

            _clientService.PutClientPhoto(id, client);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Client client)
        {
           await _clientService.AddClient(client);

            return CreatedAtAction("GetEmployee", new { id = client.Id }, client);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var status = await _clientService.Delete(id);
            if (status == "Not Found")
            {
                return NotFound();
            }

 
            return new JsonResult(status);
        }
        [Authorize]
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
