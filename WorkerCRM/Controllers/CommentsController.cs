using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkerCRM.Data;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract;
using WorkerCRM.Services.Contract.Dto;

namespace WorkerCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly WorkerCRMDbContext _context;
        private readonly ICommentService _commentService;

        public CommentsController(WorkerCRMDbContext context, ICommentService commentService)
        {
            _context = context;
            _commentService = commentService;
        }

        // GET: api/Comments
        [HttpGet]

        public List<CommentListDto> GetComments()
        {
            return _commentService.GetAll();
        }
        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetComment(int id)
        {
            var comment = await _commentService.GetById(id);

            if (comment == null)
            {
                return NotFound();
            }

            return new JsonResult(comment);
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }
            _commentService.PutComment(id, comment);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(Comment comment)
        {
            await _commentService.AddComment(comment);

            return CreatedAtAction("GetEmployee", new { id = comment.Id }, comment);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var status = await _commentService.Delete(id);
            if (status == "Not Found")
            {
                return NotFound();
            }

            return new JsonResult(status);
        }

        [HttpDelete("/api/commentsClient/{nameClient}")]
        public async Task<IActionResult> GetRating(int id)
        {
            
            _commentService.GetRating(id);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

            private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
