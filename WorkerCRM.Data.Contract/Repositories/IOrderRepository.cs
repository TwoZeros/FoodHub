using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Data.Contract.Base;
using WorkerCRM.Models;

namespace WorkerCRM.Data.Contract.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<Order> GetOrderInfo(int id);

        List<Order> GetListOrder();

        void PutOrder(Order order);

        public List<Order> GetListOrderWitnId(int id);
    }
}
