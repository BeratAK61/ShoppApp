using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class CartDto : DtoBase , IDto
    {
        public string UserId { get; set; }
    }
}
