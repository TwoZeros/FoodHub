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
using Microsoft.AspNetCore.Mvc;

namespace WorkerCRM.Data.Repositories
{
    public class ClientRepository : BaseRepository<WorkerCRM.Models.Client>, IClientRepository
    {
        private readonly WorkerCRMDbContext _context;
        public ClientRepository(WorkerCRMDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Client> GetClientInfo(int id)
        {
            return await _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public void PutClient(Client employee)
        {
            _context.Entry(employee)
             .Property(i => i.FirstName).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.SecondName).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.MiddleName).IsModified = true;
            _context.Entry(employee)
                .Property(i => i.BirthDay).IsModified = true;
        }
        public void PutClientPhoto(Client Client)
        {
            _context.Entry(Client)
             .Property(i => i.Photo).IsModified = true;
        }
        


        public List<Client> GetListClient()
        {
            return  _context.Clients.ToList();
        }

    }
}
