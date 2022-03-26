using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.DTOs
{
    public class LoginDtoWithPhoneNumber : IDto
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
