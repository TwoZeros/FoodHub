using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerCRM.Services.Contract.Dto
{
    public class ProductInOrderListDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }
}
