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
    public class EmployeeRepository : BaseRepository<WorkerCRM.Models.Employee>, IEmployeeRepository
    {
        private readonly WorkerCRMDbContext _context;
        public EmployeeRepository(WorkerCRMDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Employee> GetEmployeeInfo(int id)
        {
            return await _context.Employees.Include(p => p.User).Include(p => p.Contacts).ThenInclude(sc => sc.TypeContact)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public void PutEmployee(Employee employee)
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
        public void PutEmployeePhoto(Employee employee)
        {
            _context.Entry(employee)
             .Property(i => i.Photo).IsModified = true;
        }



        public List<Employee> GetListEmployee()
        {
            return  _context.Employees.Include(p => p.User).ToList();
        }

    }
}
