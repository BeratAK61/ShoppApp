﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.Concrete
{
    public class Product : EntityBase , IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Star { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public string Barcode { get; set; }
        public bool IsApproved { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsHome { get; set; }
        public bool IsSlider { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public int BrandId { get; set; }
        public Brand Brand { get; set; }

    }
}
