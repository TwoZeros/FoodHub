using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkerCRM.Data;
using WorkerCRM.Models;

namespace WorkerCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogEntriesController : ControllerBase
    {
        private readonly PlanersDbContext _context;

        public LogEntriesController(PlanersDbContext context)
        {
            _context = context;
        }

        // GET: api/LogEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogEntry>>> GetLogs()
        {
            return await _context.Logs.ToListAsync();
        }

        // GET: api/LogEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogEntry>> GetLogEntry(int id)
        {
            var logEntry = await _context.Logs.FindAsync(id);

            if (logEntry == null)
            {
                return NotFound();
            }

            return logEntry;
        }

        // PUT: api/LogEntries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogEntry(int id, LogEntry logEntry)
        {
            if (id != logEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(logEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogEntryExists(id))
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

        // POST: api/LogEntries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LogEntry>> PostLogEntry(LogEntry logEntry)
        {
            _context.Logs.Add(logEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogEntry", new { id = logEntry.Id }, logEntry);
        }

        // DELETE: api/LogEntries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LogEntry>> DeleteLogEntry(int id)
        {
            var logEntry = await _context.Logs.FindAsync(id);
            if (logEntry == null)
            {
                return NotFound();
            }

            _context.Logs.Remove(logEntry);
            await _context.SaveChangesAsync();

            return logEntry;
        }

        private bool LogEntryExists(int id)
        {
            return _context.Logs.Any(e => e.Id == id);
        }
    }
}
