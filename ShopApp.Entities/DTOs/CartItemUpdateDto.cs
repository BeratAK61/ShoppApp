using Core.Entities.Abstract;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class CartItemUpdateDto : DtoBase , IDto
    {
        public decimal Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
