using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract.Dto;

namespace WorkerCRM.Services.Contract
{
    public interface IEmployeeService
    {
        public Task<EmployeeDetailDto> GetById(int id);

        public List<EmployeeListDto> GetAll();
    }
}
