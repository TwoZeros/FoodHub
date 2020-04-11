﻿using AutoMapper;
using WorkerCRM.Models;
using WorkerCRM.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerCRM.Dto.Models;

namespace WorkerCRM.Infrastructure.Mappers.Interfaces
{

    public interface IOrderMapper : IModelMapper<OrderDto, OrderModel>
    {
    }

    public class OrderMapper : AbstractModelMapper<OrderDto, OrderModel>, IOrderMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDto, OrderModel>();

                cfg.CreateMap<OrderModel, OrderDto>();
            });

            return config.CreateMapper();
        }
    }
}
