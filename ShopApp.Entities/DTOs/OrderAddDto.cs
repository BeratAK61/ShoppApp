using Core.Entities.Abstract;
using ShopApp.Entities.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class OrderAddDto : IDto
    {
        public string Note { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentTypes PaymentType { get; set; }


        public string UserId { get; set; }
    }
}
