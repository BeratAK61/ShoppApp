using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class ProductListDto : IDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
