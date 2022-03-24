﻿using Core.DataAccess;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Abstract
{
    public interface IOrderItemDal : IEntityRepository<OrderItem>
    {

    }
}
