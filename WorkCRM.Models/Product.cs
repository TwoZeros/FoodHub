using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Models.Interfaces;

namespace WorkerCRM.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public List<ProductInOrder> ProductInOrder { get; set; }
    }
}
