using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Data.Contract.Base;
using System.Linq;
using WorkerCRM.Models;

namespace WorkerCRM.Data.Contract.Repositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task<Comment> GetCommentInfo(int id);

        List<Comment> GetListComment();

        void PutComment(Comment сomment);

        public List<Comment> GetListCommentWitnId(int id);

    }
}