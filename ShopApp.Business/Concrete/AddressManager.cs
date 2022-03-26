using AutoMapper;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using ShopApp.Business.Abstract;
using ShopApp.Business.Utilities;
using ShopApp.DataAccess.Abstract;
using ShopApp.Entities.Concrete;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        private readonly IMapper _mapper;

        public AddressManager(IAddressDal addressDal, IMapper mapper)
        {
            _addressDal = addressDal;
            _mapper = mapper;
        }

        public IDataResult<int> Create(AddressAddDto addressAddDto)
        {
            if (addressAddDto != null)
            {
                return new SuccessDataResult<int>(_addressDal.Create(_mapper.Map<Address>(addressAddDto)), Messages.AddingCompleted);
            }
            return new ErrorDataResult<int>(Messages.AddingCompleted);

        }

        public IResult Delete(int? id)
        {
            if (id != null)
            {
                var entity = _addressDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    _addressDal.Delete(entity);
                    return new SuccessResult(Messages.DeletingCompleted);
                }
                return new ErrorResult(Messages.DeletingNotCompleted);
            }
            return new ErrorResult(Messages.DeletingNotCompleted);
        }

        public IDataResult<List<AddressDto>> GetAll()
        {
            var entities = _addressDal.GetAll();
            if (entities != null)
            {
                if (entities.Count > 0)
                {
                    return new SuccessDataResult<List<AddressDto>>(_mapper.Map<List<AddressDto>>(entities), Messages.ListingCompleted);
                }
                return new ErrorDataResult<List<AddressDto>>(Messages.ThereIsNoDataInTable);
            }
            return new ErrorDataResult<List<AddressDto>>(Messages.ListingNotCompleted);
        }

        public IDataResult<AddressUpdateDto> GetById(int? id)
        {
            if (id != null)
            {
                var entity = _addressDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    return new SuccessDataResult<AddressUpdateDto>(_mapper.Map<AddressUpdateDto>(entity), Messages.DeletingCompleted);
                }
                return new ErrorDataResult<AddressUpdateDto>(Messages.GettingNotCompleted);
            }
            return new ErrorDataResult<AddressUpdateDto>(Messages.GettingNotCompleted);
        }

        public IResult Update(AddressUpdateDto addressUpdateDto)
        {
            if (addressUpdateDto != null)
            {
                _addressDal.Update(_mapper.Map<Address>(addressUpdateDto));
                return new SuccessResult(Messages.UpdatingCompleted);
            }
            return new ErrorResult(Messages.UpdatingNotCompleted);
        }
    }
}
