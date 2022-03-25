﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class BrandListDto : IDto
    {
        public List<BrandDto> Brands { get; set; }
    }
}
