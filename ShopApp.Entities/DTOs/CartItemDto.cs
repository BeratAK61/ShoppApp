using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class CartItemDto : DtoBase , IDto
    {
        public decimal Quantity { get; set; }

        public int ProductId { get; set; }

        public int CartId { get; set; }
    }
}
