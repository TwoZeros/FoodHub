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
               cfg.CreateMap<EmployeeContact, ContactDto>()
               .ForMember(x => x.Name, s => s.MapFrom(x => x.TypeContact.Name))
                .ForMember(x => x.Id, s => s.MapFrom(x => x.TypeContactId))
                .ForMember(x => x.Value, s => s.MapFrom(x => x.Value));
               
                cfg.CreateMap<EmployeeDetailDto, Employee>();

                cfg.CreateMap<Employee, EmployeeDetailDto>();
            });

            return config.CreateMapper();
        }
    }
}
