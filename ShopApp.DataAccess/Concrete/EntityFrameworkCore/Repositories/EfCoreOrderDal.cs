using Core.DataAccess.EntityFrameworkCore;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfCoreOrderDal : EfCoreEntityRepository<Order> , IOrderDal
    {
        public EfCoreOrderDal(ShopContext context) : base(context)
        {

        }
    }
}
