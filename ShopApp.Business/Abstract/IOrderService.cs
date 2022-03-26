using Core.Utilities.Results.Abstract;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<OrderDto>> GetAll();
        IDataResult<OrderUpdateDto> GetById(int? id);
        IDataResult<int> Create(OrderAddDto orderAddDto);
        IResult Update(OrderUpdateDto orderUpdateDto);
        IResult Delete(int? id);
    }
}
