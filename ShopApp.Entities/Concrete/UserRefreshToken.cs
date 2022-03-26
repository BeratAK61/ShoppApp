using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Entities.Concrete
{
    public class UserRefreshToken : EntityBase , IEntity
    {
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
        public string UserId { get; set; }
    }
}
