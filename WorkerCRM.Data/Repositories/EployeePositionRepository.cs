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
    public class EployeePositionRepository : BaseRepository<Position>, IEmployeePositionRepository
    {
        private readonly WorkerCRMDbContext _context;
        public EployeePositionRepository(WorkerCRMDbContext context) : base(context)
        {
            _context = context;
        }

       

    }
}
