using WorkerCRM.Data.Contract.Base;
using WorkerCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerCRM.Data.Contract.Repositories
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        List<Client> GetListClient();
        Task<Client> GetClientInfo(int id);
        void PutClient(Client employee);
        void PutClientPhoto(Client employee);
    }
    
}
