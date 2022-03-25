using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class OrderItemListDto : IDto
    {
        public List<OrderItemDto> OrderItems { get; set; }
    }
}
