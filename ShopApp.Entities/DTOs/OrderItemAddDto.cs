using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class OrderItemAddDto : IDto
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
