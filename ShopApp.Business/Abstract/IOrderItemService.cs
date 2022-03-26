using Core.Utilities.Results.Abstract;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IOrderItemService
    {
        IDataResult<List<OrderItemDto>> GetAll();
        IDataResult<OrderItemUpdateDto> GetById(int? id);
        IDataResult<int> Create(OrderItemAddDto orderItemAddDto);
        IResult Update(OrderItemUpdateDto orderItemUpdateDto);
        IResult Delete(int? id);
    }
}
