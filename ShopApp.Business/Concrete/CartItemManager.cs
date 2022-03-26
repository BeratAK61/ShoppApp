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
    public class CartItemManager : ICartItemService
    {
        private readonly ICartItemDal _cartItemDal;
        private readonly IMapper _mapper;
        public CartItemManager(ICartItemDal cartItemDal, IMapper mapper)
        {
            _cartItemDal = cartItemDal;
            _mapper = mapper;
        }

        public IDataResult<int> Create(CartItemAddDto cartItemAddDto)
        {
            if (cartItemAddDto != null)
            {
                return new SuccessDataResult<int>(_cartItemDal.Create(_mapper.Map<CartItem>(cartItemAddDto)), Messages.AddingCompleted);
            }
            return new ErrorDataResult<int>(Messages.AddingCompleted);

        }

        public IResult Delete(int? id)
        {
            if (id != null)
            {
                var entity = _cartItemDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    _cartItemDal.Delete(entity);
                    return new SuccessResult(Messages.DeletingCompleted);
                }
                return new ErrorResult(Messages.DeletingNotCompleted);
            }
            return new ErrorResult(Messages.DeletingNotCompleted);
        }

        public IDataResult<List<CartItemDto>> GetAll()
        {
            var entities = _cartItemDal.GetAll();
            if (entities != null)
            {
                if (entities.Count > 0)
                {
                    return new SuccessDataResult<List<CartItemDto>>(_mapper.Map<List<CartItemDto>>(entities), Messages.ListingCompleted);
                }
                return new ErrorDataResult<List<CartItemDto>>(Messages.ThereIsNoDataInTable);
            }
            return new ErrorDataResult<List<CartItemDto>>(Messages.ListingNotCompleted);
        }

        public IDataResult<CartItemUpdateDto> GetById(int? id)
        {
            if (id != null)
            {
                var entity = _cartItemDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    return new SuccessDataResult<CartItemUpdateDto>(_mapper.Map<CartItemUpdateDto>(entity), Messages.DeletingCompleted);
                }
                return new ErrorDataResult<CartItemUpdateDto>(Messages.GettingNotCompleted);
            }
            return new ErrorDataResult<CartItemUpdateDto>(Messages.GettingNotCompleted);
        }

        public IResult Update(CartItemUpdateDto cartItemUpdateDto)
        {
            if (cartItemUpdateDto != null)
            {
                _cartItemDal.Update(_mapper.Map<CartItem>(cartItemUpdateDto));
                return new SuccessResult(Messages.UpdatingCompleted);
            }
            return new ErrorResult(Messages.UpdatingNotCompleted);
        }
    }
}
