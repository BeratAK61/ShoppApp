using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class BrandAddDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
