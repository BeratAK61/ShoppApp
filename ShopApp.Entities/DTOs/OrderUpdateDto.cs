using Core.Entities.Abstract;
using ShopApp.Entities.ComplexTypes;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class OrderUpdateDto : DtoBase , IDto
    {
        public string Note { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }


        public OrderState OrderState { get; set; }
        public PaymentTypes PaymentType { get; set; }

        public Address Addresses { get; set; }


        public string UserId { get; set; }
    }
}
