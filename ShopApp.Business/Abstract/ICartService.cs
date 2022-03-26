using Core.Utilities.Results.Abstract;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface ICartService
    {
        IDataResult<List<CartDto>> GetAll();
        IDataResult<CartUpdateDto> GetById(int? id);
        IDataResult<int> Create(CartAddDto cartAddDto);
        IResult Update(CartUpdateDto cartUpdateDto);
        IResult Delete(int? id);
    }
}
