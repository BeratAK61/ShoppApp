using Core.Utilities.Results.Abstract;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<CategoryDto>> GetAll();
        IDataResult<CategoryUpdateDto> GetById(int? id);
        IDataResult<int> Create(CategoryAddDto categoryAddDto);
        IResult Update(CategoryUpdateDto categoryUpdateDto);
        IResult Delete(int? id);
    }
}
