using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.Concrete
{
    public class Cart : EntityBase , IEntity
    {
        public string UserId { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
