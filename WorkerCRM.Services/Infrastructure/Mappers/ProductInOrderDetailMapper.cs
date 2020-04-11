using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract.Dto;
using WorkerCRM.Services.Infrastructure.Mappers.Interfaces;

namespace WorkerCRM.Services.Infrastructure.Mappers
{
    public interface IProductInOrderDetailMapper : IModelMapper<ProductInOrderDetailDto, ProductInOrder>
    {
    }
    public class ProductInOrderDetailMapper : AbstractModelMapper<ProductInOrderDetailDto, ProductInOrder>, IProductInOrderDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductInOrderDetailDto, ProductInOrder>();

                cfg.CreateMap<ProductInOrder, ProductInOrderDetailDto>();
            });

            return config.CreateMapper();
        }
    }
}
