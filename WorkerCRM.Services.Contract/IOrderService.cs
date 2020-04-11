using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Models;
using WorkerCRM.Services.Contract.Dto;

namespace WorkerCRM.Services.Contract
{
    public interface IOrderService
    {
        public Task<OrderDetailDto> GetById(int id);

        public List<OrderListDto> GetAll();

        public Task<string> Delete(int id);
        public Task AddOrder(Order comment);
        public void PutOrder(int id, Order comment);
    }
}
