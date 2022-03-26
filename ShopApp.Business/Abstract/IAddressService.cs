using Core.Utilities.Results.Abstract;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Abstract
{
    public interface IAddressService
    {
        IDataResult<List<AddressDto>> GetAll();
        IDataResult<AddressUpdateDto> GetById(int? id);
        IDataResult<int> Create(AddressAddDto addressAddDto);
        IResult Update(AddressUpdateDto addressUpdateDto);
        IResult Delete(int? id);
    }
}
