using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract.Dto;
using WorkerCRM.Services.Infrastructure.Mappers.Interfaces;

namespace WorkerCRM.Services.Infrastructure.Mappers
{
    public interface IProductDetailMapper : IModelMapper<ProductDetailDto, Product>
    {
    }
    public class ProductDetailMapper : AbstractModelMapper<ProductDetailDto, Product>, IProductDetailMapper
    {
        protected override IMapper Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDetailDto, Product>();

                cfg.CreateMap<Product, ProductDetailDto>();
            });

            return config.CreateMapper();
        }
    }
}
