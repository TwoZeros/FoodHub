using WorkerCRM.Data.Base;
using WorkerCRM.Data.Contract.Repositories;
using WorkerCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WorkerCRM.Data.Contract.Base;
using System.Threading.Tasks;

namespace WorkerCRM.Data.Repositories
{
    public class LogRepository : BaseRepository<WorkerCRM.Models.LogEntry>, ILogRepository
    {
        public LogRepository(PlanersDbContext context) : base(context)
        {

        }

       

    }
}
