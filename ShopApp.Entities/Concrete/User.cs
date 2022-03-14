using Core.Entities.Abstract;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.Concrete
{
    public class User : IdentityUser , IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }



        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; }

    }
}
