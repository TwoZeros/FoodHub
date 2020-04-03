using AutoMapper;
using WorkerCRM.Models;
using WorkerCRM.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerCRM.Services.Contract.Dto;
using WorkerCRM.Services.Infrastructure.Mappers.Interfaces;

namespace WorkerCRM.Services.Infrastructure.Mappers
{

    public interface IEmployeeDetailMapper : IModelMapper<EmployeeDetailDto, Employee>
    {
    }

    public class EmployeeDetailMapper : AbstractModelMapper<EmployeeDetailDto, Employee>, IEmployeeDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeDetailDto, Employee>();

                cfg.CreateMap<Employee, EmployeeDetailDto>();
            });

            return config.CreateMapper();
        }
    }
}
