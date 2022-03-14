using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.Concrete
{
    public class CartItem : EntityBase , IEntity    
    {
        public decimal Quantity { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }


        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
