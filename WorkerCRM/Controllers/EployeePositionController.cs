﻿using System;
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
    public class EmployeePosition : ControllerBase
    {
        private readonly WorkerCRMDbContext _context;
        private readonly IEmployeePositionService _employeePositiontService;
        public EmployeePosition(WorkerCRMDbContext context, IEmployeePositionService employeePositionService)
        {
            _context = context;
            _employeePositiontService = employeePositionService;
        }

        // GET: api/Client
        [HttpGet]
        public List<Position> GetPositions()
        {
   
        return _employeePositiontService.GetAll();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPosition(int id)
        {
            var position = await _employeePositiontService.GetById(id);

            if (position == null)
            {
                return NotFound();
            }

            return new JsonResult(position);
        }

        // PUT: api/Client/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Position position)
        {
            if (id != position.Id)
                return BadRequest();

            _employeePositiontService.Update(position);

            return NoContent();
        }

       

        // POST: api/Client

        [HttpPost]
        public async Task<ActionResult<Position>> PostClient(Position position)
        {
            await _employeePositiontService.Add(position);

            return CreatedAtAction("GetPosition", new { id = position.Id }, position);
        }

        // DELETE: api/Client/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var status = await _employeePositiontService.Delete(id);
            if (status == "Not Found")
            {
                return NotFound();
            }

 
            return new JsonResult(status);
        }
        private bool PositionExists(int id)
        {
            return _context.Positions.Any(e => e.Id == id);
        }
    }
}
