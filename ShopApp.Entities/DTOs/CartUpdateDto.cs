using Core.Entities.Abstract;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class CartUpdateDto : DtoBase , IDto
    {
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
