using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Data.Contract.Base;
using WorkerCRM.Models;

namespace WorkerCRM.Data.Contract.Repositories
{
    public interface IProductInOrderRepository : IBaseRepository<ProductInOrder>
    {
        List<ProductInOrder> GetListProductInOrder();
        Task<ProductInOrder> GetProductInOrderInfo(int id);
        void PutProductInOrder(ProductInOrder employee);
    }
}
