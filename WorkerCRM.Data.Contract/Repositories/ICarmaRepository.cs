using WorkerCRM.Data.Contract.Base;
using WorkerCRM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerCRM.Data.Contract.Repositories
{
    public interface ICarmaRepository : IBaseRepository<CarmaUser>
    {
        Task<CarmaUser> GetStatusByNumber(int number);
        void PutCarmaClient(CarmaUser carmaUser);
    }
}