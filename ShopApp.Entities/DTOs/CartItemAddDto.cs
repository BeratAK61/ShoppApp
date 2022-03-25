using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class CartItemAddDto : IDto
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
    }
}
