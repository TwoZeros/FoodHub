using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Models.Interfaces;

namespace WorkerCRM.Models
{
    public class ProductInOrder : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public Order Order { get; set; }
    }
}
