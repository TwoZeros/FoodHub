using WorkerCRM.Data.Contract.Base;
using WorkerCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace WorkerCRM.Data.Contract.Repositories
{
    public interface IAuthorizationRepository : IBaseRepository<User>
    {

        public User GetUserByIndentity(string username, string password);
    }
    
}
