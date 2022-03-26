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
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;
        private readonly IMapper _mapper;
        public BrandManager(IBrandDal brandDal, IMapper mapper)
        {
            _brandDal = brandDal;
            _mapper = mapper;
        }


        public IDataResult<int> Create(BrandAddDto brandAddDto)
        {
            if (brandAddDto != null)
            {
                return new SuccessDataResult<int>(_brandDal.Create(_mapper.Map<Brand>(brandAddDto)), Messages.AddingCompleted);
            }
            return new ErrorDataResult<int>(Messages.AddingCompleted);

        }

        public IResult Delete(int? id)
        {
            if (id != null)
            {
                var entity = _brandDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    _brandDal.Delete(entity);
                    return new SuccessResult(Messages.DeletingCompleted);
                }
                return new ErrorResult(Messages.DeletingNotCompleted);
            }
            return new ErrorResult(Messages.DeletingNotCompleted);
        }

        public IDataResult<List<BrandDto>> GetAll()
        {
            var entities = _brandDal.GetAll();
            if (entities != null)
            {
                if (entities.Count > 0)
                {
                    return new SuccessDataResult<List<BrandDto>>(_mapper.Map<List<BrandDto>>(entities), Messages.ListingCompleted);
                }
                return new ErrorDataResult<List<BrandDto>>(Messages.ThereIsNoDataInTable);
            }
            return new ErrorDataResult<List<BrandDto>>(Messages.ListingNotCompleted);
        }

        public IDataResult<BrandUpdateDto> GetById(int? id)
        {
            if (id != null)
            {
                var entity = _brandDal.Get(b => b.Id == (int)id);
                if (entity != null)
                {
                    return new SuccessDataResult<BrandUpdateDto>(_mapper.Map<BrandUpdateDto>(entity), Messages.DeletingCompleted);
                }
                return new ErrorDataResult<BrandUpdateDto>(Messages.GettingNotCompleted);
            }
            return new ErrorDataResult<BrandUpdateDto>(Messages.GettingNotCompleted);
        }

        public IResult Update(BrandUpdateDto brandUpdateDto)
        {
            if (brandUpdateDto != null)
            {
                _brandDal.Update(_mapper.Map<Brand>(brandUpdateDto));
                return new SuccessResult(Messages.UpdatingCompleted);
            }
            return new ErrorResult(Messages.UpdatingNotCompleted);
        }

    }
}
