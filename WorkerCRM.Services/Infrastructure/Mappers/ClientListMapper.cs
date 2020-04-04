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

    public interface IClientListMapper : IModelMapper<ClientListDto, Employee>
    {
    }

    public class ClientListMapper : AbstractModelMapper<ClientListDto, Employee>, IClientListMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap < ClientListDto, Client>();

                cfg.CreateMap<Employee, EmployeeListDto>()
                .ForMember(x => x.BirthDay, s => s.MapFrom(x => x.BirthDay.ToString("d")))
                .ForMember(x => x.Created, s => s.MapFrom(x => x.CreatedDate.ToString("d")));
            });

            return config.CreateMapper();
        }
    }
}
