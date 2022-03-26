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
    public class CartManager : ICartService
    {
        private readonly ICartDal _cartDal;
        private readonly IMapper _mapper;
        public CartManager(ICartDal cartDal, IMapper mapper)
        {
            _cartDal = cartDal;
            _mapper = mapper;
        }

        public IDataResult<int> Create(CartAddDto cartAddDto)
        {
            if (cartAddDto != null)
            {
                return new SuccessDataResult<int>(_cartDal.Create(_mapper.Map<Cart>(cartAddDto)), Messages.AddingCompleted);
            }
            return new ErrorDataResult<int>(Messages.AddingCompleted);

        }

        public IResult Delete(int? id)
        {
            if (id != null)
            {
                var entity = _cartDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    _cartDal.Delete(entity);
                    return new SuccessResult(Messages.DeletingCompleted);
                }
                return new ErrorResult(Messages.DeletingNotCompleted);
            }
            return new ErrorResult(Messages.DeletingNotCompleted);
        }

        public IDataResult<List<CartDto>> GetAll()
        {
            var entities = _cartDal.GetAll();
            if (entities != null)
            {
                if (entities.Count > 0)
                {
                    return new SuccessDataResult<List<CartDto>>(_mapper.Map<List<CartDto>>(entities), Messages.ListingCompleted);
                }
                return new ErrorDataResult<List<CartDto>>(Messages.ThereIsNoDataInTable);
            }
            return new ErrorDataResult<List<CartDto>>(Messages.ListingNotCompleted);
        }

        public IDataResult<CartUpdateDto> GetById(int? id)
        {
            if (id != null)
            {
                var entity = _cartDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    return new SuccessDataResult<CartUpdateDto>(_mapper.Map<CartUpdateDto>(entity), Messages.DeletingCompleted);
                }
                return new ErrorDataResult<CartUpdateDto>(Messages.GettingNotCompleted);
            }
            return new ErrorDataResult<CartUpdateDto>(Messages.GettingNotCompleted);
        }

        public IResult Update(CartUpdateDto cartUpdateDto)
        {
            if (cartUpdateDto != null)
            {
                _cartDal.Update(_mapper.Map<Cart>(cartUpdateDto));
                return new SuccessResult(Messages.UpdatingCompleted);
            }
            return new ErrorResult(Messages.UpdatingNotCompleted);
        }
    }
}
