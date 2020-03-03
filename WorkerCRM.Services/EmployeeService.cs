using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Data.Contract.Repositories;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract;
using WorkerCRM.Services.Contract.Dto;
using WorkerCRM.Services.Infrastructure.Mappers;

namespace WorkerCRM.Services
{
    
    public class EmployeeService :IEmployeeService
    {
        public IEmployeeRepository _repo;

        private readonly IEmployeeDetailMapper _detailMapper;
        private readonly IEmployeeListMapper _listMapper;
        public EmployeeService(IEmployeeRepository repo, IEmployeeDetailMapper detailMapper, IEmployeeListMapper listMapper  )
        {
            _detailMapper = detailMapper;
            _listMapper = listMapper;
            _repo = repo;
 
        }

        public async Task<EmployeeDetailDto> GetById(int id)
        {
            var employee = await _repo.GetEmployeeInfo(id);
            var employeeDto = _detailMapper.Map<Employee, EmployeeDetailDto>(employee);

            return employeeDto;
        }

        public List<EmployeeListDto> GetAll() { 
        var employee = _repo.GetListEmployee();
            return _listMapper.Map<List<Employee>, List<EmployeeListDto> >(employee);
        }
    }
}
