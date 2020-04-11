using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerCRM.Data.Base;
using WorkerCRM.Data.Contract.Repositories;
using WorkerCRM.Models;

namespace WorkerCRM.Data.Repositories
{
    public class OrderRepository : BaseRepository<WorkerCRM.Models.Order>, IOrderRepository
    {
        private readonly WorkerCRMDbContext _context;
        public OrderRepository(WorkerCRMDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Order> GetOrderInfo(int id)
        {
            return await _context.Orders.Include(p => p.Client).Include(p => p.User).Include(p => p.StatusOrder)
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);
        }
        public List<Order> GetListOrder()
        {
            return _context.Orders.Include(p => p.Client).Include(p => p.User).Include(p => p.StatusOrder).ToList();
        }

        public void PutOrder(Order order)
        {
            _context.Entry(order)
                .Property(i => i.Name).IsModified = true;
            _context.Entry(order)
                .Property(i => i.DateCreate).IsModified = true;
        }
        public List<Order> GetListOrderWitnId(int id)
        {
            return _context.Orders.Where(p => p.StatusId == id).ToList();
        }
    }
}
