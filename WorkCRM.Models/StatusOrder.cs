using System;
using System.Collections.Generic;
using System.Text;
using WorkerCRM.Models.Interfaces;

namespace WorkerCRM.Models
{
    public class StatusOrder : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
    }
}
