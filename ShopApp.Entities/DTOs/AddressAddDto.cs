using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class AddressAddDto :  IDto
    {
        public string AddressTitle { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber { get; set; }
        public string ApartmentName { get; set; }
        public string AddressDescription { get; set; }


        public string UserId { get; set; }
    }
}
