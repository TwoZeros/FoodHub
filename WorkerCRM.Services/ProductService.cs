using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Data.Contract.Repositories;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract;
using WorkerCRM.Services.Contract.Dto;
using WorkerCRM.Services.Infrastructure.Mappers;

namespace WorkerCRM.Services
{
    public class ProductService : IProductService
    {
        public IProductRepository _repo;

        private readonly IProductDetailMapper _detailMapper;
        private readonly IProductListMapper _listMapper;

        public ProductService(IProductRepository repo, IProductDetailMapper detailMapper, IProductListMapper listMapper)
        {
            _detailMapper = detailMapper;
            _listMapper = listMapper;
            _repo = repo;
        }
        public async Task<ProductDetailDto> GetById(int id)
        {
            var product = await _repo.GetProductInfo(id);
            var productDto = _detailMapper.Map<Product, ProductDetailDto>(product);

            return productDto;
        }
        public List<ProductListDto> GetAll()
        {
            var product = _repo.GetListProduct();
            return _listMapper.Map<List<Product>, List<ProductListDto>>(product);
        }

        public async Task<string> Delete(int id)
        {
            var product = await _repo.GetProductInfo(id);
            if (product != null)
            {
                await _repo.Delete(id);
                await _repo.SaveAsync();
                return "OK";
            }
            return "Not Found";
        }
        public async Task AddProduct(Product product)
        {
            _repo.Add(product);
            await _repo.SaveAsync();
        }
        public void PutProduct(int id, Product product)
        {
            _repo.PutProduct(product);
        }
    }
}
