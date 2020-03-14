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
    public class TypeContactsController : ControllerBase
    {
        private readonly WorkerCRMDbContext _context;

        public TypeContactsController(WorkerCRMDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeContacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeContact>>> GetTypeContact()
        {
            return await _context.TypeContact.ToListAsync();
        }

        // GET: api/TypeContacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeContact>> GetTypeContact(int id)
        {
            var typeContact = await _context.TypeContact.FindAsync(id);

            if (typeContact == null)
            {
                return NotFound();
            }

            return typeContact;
        }

        // PUT: api/TypeContacts/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeContact(int id, TypeContact typeContact)
        {
            if (id != typeContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeContactExists(id))
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

        // POST: api/TypeContacts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TypeContact>> PostTypeContact(TypeContact typeContact)
        {
            _context.TypeContact.Add(typeContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeContact", new { id = typeContact.Id }, typeContact);
        }

        // DELETE: api/TypeContacts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeContact>> DeleteTypeContact(int id)
        {
            var typeContact = await _context.TypeContact.FindAsync(id);
            if (typeContact == null)
            {
                return NotFound();
            }

            _context.TypeContact.Remove(typeContact);
            await _context.SaveChangesAsync();

            return typeContact;
        }

        private bool TypeContactExists(int id)
        {
            return _context.TypeContact.Any(e => e.Id == id);
        }
    }
}
