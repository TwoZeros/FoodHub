using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Data.Base;
using WorkerCRM.Data.Contract.Repositories;
using WorkerCRM.Models;

namespace WorkerCRM.Data.Repositories
{
    public class CommentRepository : BaseRepository<WorkerCRM.Models.Comment>, ICommentRepository
    {
        private readonly WorkerCRMDbContext _context;

        public CommentRepository(WorkerCRMDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Comment> GetCommentInfo(int id)
        {
            return await _context.Comments.Include(p => p.Text)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public List<Comment> GetListComment()
        {
            return _context.Comments.Include(p => p.Client).ToList();
        }

        public void PutComment(Comment сomment)
        {
            _context.Entry(сomment)
                .Property(i => i.Text).IsModified = true;
            _context.Entry(сomment)
                .Property(i => i.CreateDate).IsModified = true;
            _context.Entry(сomment)
                .Property(i => i.Karma).IsModified = true;
        }
        public List<Comment> GetListCommentWitnId(int id)
        {
            return _context.Comments.Where(p => p.IdClient == id).ToList();
        }
    }
}