using WorkerCRM.Data.Base;
using WorkerCRM.Data.Contract.Repositories;
using WorkerCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WorkerCRM.Data.Contract.Base;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WorkerCRM.Data.Repositories
{
    public class AuthorizationRepository : BaseRepository<WorkerCRM.Models.User>, IAuthorizationRepository
    {
        private readonly WorkerCRMDbContext _context;
        public AuthorizationRepository(WorkerCRMDbContext context) : base(context)
        {
            _context = context;
        }
        public User GetUserByIndentity(string username, string password)
        {
            return  _context.Users.FirstOrDefault(x => x.Login == username && x.Password == password);
        }


       

    }
}
