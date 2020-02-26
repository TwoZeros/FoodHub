using AutoMapper;
using WorkerCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerCRM.Services.Dto;

namespace WorkerCRM.AutoMapper
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            CreateMap<OrderModel, OrderDto>();
        }
    }
}
