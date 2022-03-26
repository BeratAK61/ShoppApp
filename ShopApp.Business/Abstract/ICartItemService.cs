using Core.Utilities.Results.Abstract;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface ICartItemService
    {
        IDataResult<List<CartItemDto>> GetAll();
        IDataResult<CartItemUpdateDto> GetById(int? id);
        IDataResult<int> Create(CartItemAddDto cartItemAddDto);
        IResult Update(CartItemUpdateDto cartItemUpdateDto);
        IResult Delete(int? id);
    }
}
