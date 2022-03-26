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
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;
        public ProductManager(IProductDal productDal, IMapper mapper)
        {
            _productDal = productDal;
            _mapper = mapper;
        }
        public IDataResult<int> Create(ProductAddDto productAddDto)
        {
            if (productAddDto != null)
            {
                return new SuccessDataResult<int>(_productDal.Create(_mapper.Map<Product>(productAddDto)), Messages.AddingCompleted);
            }
            return new ErrorDataResult<int>(Messages.AddingCompleted);

        }

        public IResult Delete(int? id)
        {
            if (id != null)
            {
                var entity = _productDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    _productDal.Delete(entity);
                    return new SuccessResult(Messages.DeletingCompleted);
                }
                return new ErrorResult(Messages.DeletingNotCompleted);
            }
            return new ErrorResult(Messages.DeletingNotCompleted);
        }

        public IDataResult<List<ProductDto>> GetAll()
        {
            var entities = _productDal.GetAll();
            if (entities != null)
            {
                if (entities.Count > 0)
                {
                    return new SuccessDataResult<List<ProductDto>>(_mapper.Map<List<ProductDto>>(entities), Messages.ListingCompleted);
                }
                return new ErrorDataResult<List<ProductDto>>(Messages.ThereIsNoDataInTable);
            }
            return new ErrorDataResult<List<ProductDto>>(Messages.ListingNotCompleted);
        }

        public IDataResult<ProductUpdateDto> GetById(int? id)
        {
            if (id != null)
            {
                var entity = _productDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    return new SuccessDataResult<ProductUpdateDto>(_mapper.Map<ProductUpdateDto>(entity), Messages.DeletingCompleted);
                }
                return new ErrorDataResult<ProductUpdateDto>(Messages.GettingNotCompleted);
            }
            return new ErrorDataResult<ProductUpdateDto>(Messages.GettingNotCompleted);
        }

        public IResult Update(ProductUpdateDto productUpdateDto)
        {
            if (productUpdateDto != null)
            {
                _productDal.Update(_mapper.Map<Product>(productUpdateDto));
                return new SuccessResult(Messages.UpdatingCompleted);
            }
            return new ErrorResult(Messages.UpdatingNotCompleted);
        }
    }
}
