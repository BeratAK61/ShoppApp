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
    public class OrderItemManager : IOrderItemService
    {

        private readonly IOrderItemDal _orderItemDal;
        private readonly IMapper _mapper;
        public OrderItemManager(IOrderItemDal orderItemDal, IMapper mapper)
        {
            _orderItemDal = orderItemDal;
            _mapper = mapper;
        }

        public IDataResult<int> Create(OrderItemAddDto orderItemAddDto)
        {
            if (orderItemAddDto != null)
            {
                return new SuccessDataResult<int>(_orderItemDal.Create(_mapper.Map<OrderItem>(orderItemAddDto)), Messages.AddingCompleted);
            }
            return new ErrorDataResult<int>(Messages.AddingCompleted);

        }

        public IResult Delete(int? id)
        {
            if (id != null)
            {
                var entity = _orderItemDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    _orderItemDal.Delete(entity);
                    return new SuccessResult(Messages.DeletingCompleted);
                }
                return new ErrorResult(Messages.DeletingNotCompleted);
            }
            return new ErrorResult(Messages.DeletingNotCompleted);
        }

        public IDataResult<List<OrderItemDto>> GetAll()
        {
            var entities = _orderItemDal.GetAll();
            if (entities != null)
            {
                if (entities.Count > 0)
                {
                    return new SuccessDataResult<List<OrderItemDto>>(_mapper.Map<List<OrderItemDto>>(entities), Messages.ListingCompleted);
                }
                return new ErrorDataResult<List<OrderItemDto>>(Messages.ThereIsNoDataInTable);
            }
            return new ErrorDataResult<List<OrderItemDto>>(Messages.ListingNotCompleted);
        }

        public IDataResult<OrderItemUpdateDto> GetById(int? id)
        {
            if (id != null)
            {
                var entity = _orderItemDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    return new SuccessDataResult<OrderItemUpdateDto>(_mapper.Map<OrderItemUpdateDto>(entity), Messages.DeletingCompleted);
                }
                return new ErrorDataResult<OrderItemUpdateDto>(Messages.GettingNotCompleted);
            }
            return new ErrorDataResult<OrderItemUpdateDto>(Messages.GettingNotCompleted);
        }

        public IResult Update(OrderItemUpdateDto orderItemUpdateDto)
        {
            if (orderItemUpdateDto != null)
            {
                _orderItemDal.Update(_mapper.Map<OrderItem>(orderItemUpdateDto));
                return new SuccessResult(Messages.UpdatingCompleted);
            }
            return new ErrorResult(Messages.UpdatingNotCompleted);
        }
    }
}
