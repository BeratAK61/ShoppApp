using Core.Utilities.Results.Abstract;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<ProductDto>> GetAll();
        IDataResult<ProductUpdateDto> GetById(int? id);
        IDataResult<int> Create(ProductAddDto productAddDto);
        IResult Update(ProductUpdateDto productUpdateDto);
        IResult Delete(int? id);
    }
}
