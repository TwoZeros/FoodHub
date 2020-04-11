using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract.Base;
using WorkerCRM.Services.Contract.Dto;

namespace WorkerCRM.Services.Contract
{
    public interface IEmployeePositionService : IBaseServices<Position>
    {
        Task Update(Position position);
    }
}
