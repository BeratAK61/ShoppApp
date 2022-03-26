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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IMapper _mapper;
        public OrderManager(IOrderDal orderDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _mapper = mapper;
        }

        public IDataResult<int> Create(OrderAddDto orderAddDto)
        {
            if (orderAddDto != null)
            {
                return new SuccessDataResult<int>(_orderDal.Create(_mapper.Map<Order>(orderAddDto)), Messages.AddingCompleted);
            }
            return new ErrorDataResult<int>(Messages.AddingCompleted);

        }

        public IResult Delete(int? id)
        {
            if (id != null)
            {
                var entity = _orderDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    _orderDal.Delete(entity);
                    return new SuccessResult(Messages.DeletingCompleted);
                }
                return new ErrorResult(Messages.DeletingNotCompleted);
            }
            return new ErrorResult(Messages.DeletingNotCompleted);
        }

        public IDataResult<List<OrderDto>> GetAll()
        {
            var entities = _orderDal.GetAll();
            if (entities != null)
            {
                if (entities.Count > 0)
                {
                    return new SuccessDataResult<List<OrderDto>>(_mapper.Map<List<OrderDto>>(entities), Messages.ListingCompleted);
                }
                return new ErrorDataResult<List<OrderDto>>(Messages.ThereIsNoDataInTable);
            }
            return new ErrorDataResult<List<OrderDto>>(Messages.ListingNotCompleted);
        }

        public IDataResult<OrderUpdateDto> GetById(int? id)
        {
            if (id != null)
            {
                var entity = _orderDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    return new SuccessDataResult<OrderUpdateDto>(_mapper.Map<OrderUpdateDto>(entity), Messages.DeletingCompleted);
                }
                return new ErrorDataResult<OrderUpdateDto>(Messages.GettingNotCompleted);
            }
            return new ErrorDataResult<OrderUpdateDto>(Messages.GettingNotCompleted);
        }

        public IResult Update(OrderUpdateDto orderUpdateDto)
        {
            if (orderUpdateDto != null)
            {
                _orderDal.Update(_mapper.Map<Order>(orderUpdateDto));
                return new SuccessResult(Messages.UpdatingCompleted);
            }
            return new ErrorResult(Messages.UpdatingNotCompleted);
        }
    }
}
