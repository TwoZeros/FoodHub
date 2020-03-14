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
    public class EmployeesController : ControllerBase
    {
        private readonly WorkerCRMDbContext _context;
        private readonly IEmployeeService _employeeService;
        public EmployeesController(WorkerCRMDbContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public List<EmployeeListDto> GetEmployees()
        {
   
        return _employeeService.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return new JsonResult(employee);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            _employeeService.PutEmployee(id, employee);

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
        [Authorize]
        public async Task<IActionResult> PutEmployeePhoto(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            _employeeService.PutEmployeePhoto(id, employee);

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
        [Authorize]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
           await _employeeService.AddEmployee(employee);

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var status = await _employeeService.Delete(id);
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
