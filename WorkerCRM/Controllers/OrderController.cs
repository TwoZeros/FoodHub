using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WorkerCRM.Infrastructure.Mappers.Interfaces;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract;
using Serilog;
using WorkerCRM.Data;
using WorkerCRM.Services.Contract.Dto;
using Microsoft.EntityFrameworkCore;

namespace WorkerCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly WorkerCRMDbContext _context;
        private readonly IOrderService _orderService;
        public OrderController(WorkerCRMDbContext context, IOrderService orderService)
        {
            _context = context;
            _orderService = orderService;
        }

        // GET: api/Employees
        [HttpGet]
        public List<OrderListDto> GetOrders()
        {

            return _orderService.GetAll();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrder(int id)
        {
            var order = await _orderService.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return new JsonResult(order);
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
                return BadRequest();

            _orderService.PutOrder(id, order);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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
        public async Task<ActionResult<Employee>> PostOrder(Order order)
        {
            await _orderService.AddOrder(order);

            return CreatedAtAction("GetEmployee", new { id = order.Id }, order);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var status = await _orderService.Delete(id);
            if (status == "Not Found")
            {
                return NotFound();
            }


            return new JsonResult(status);
        }
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}