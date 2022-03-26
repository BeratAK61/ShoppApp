using Core.Utilities.Results.Abstract;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IBrandService
    {
        IDataResult<List<BrandDto>> GetAll();
        IDataResult<BrandUpdateDto> GetById(int? id);
        IDataResult<int> Create(BrandAddDto brandAddDto);
        IResult Update(BrandUpdateDto brandUpdateDto);
        IResult Delete(int? id);
    }
}
