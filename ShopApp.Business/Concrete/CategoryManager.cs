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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public IDataResult<int> Create(CategoryAddDto categoryAddDto)
        {
            if (categoryAddDto != null)
            {
                return new SuccessDataResult<int>(_categoryDal.Create(_mapper.Map<Category>(categoryAddDto)), Messages.AddingCompleted);
            }
            return new ErrorDataResult<int>(Messages.AddingCompleted);

        }

        public IResult Delete(int? id)
        {
            if (id != null)
            {
                var entity = _categoryDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    _categoryDal.Delete(entity);
                    return new SuccessResult(Messages.DeletingCompleted);
                }
                return new ErrorResult(Messages.DeletingNotCompleted);
            }
            return new ErrorResult(Messages.DeletingNotCompleted);
        }

        public IDataResult<List<CategoryDto>> GetAll()
        {
            var entities = _categoryDal.GetAll();
            if (entities != null)
            {
                if (entities.Count > 0)
                {
                    return new SuccessDataResult<List<CategoryDto>>(_mapper.Map<List<CategoryDto>>(entities), Messages.ListingCompleted);
                }
                return new ErrorDataResult<List<CategoryDto>>(Messages.ThereIsNoDataInTable);
            }
            return new ErrorDataResult<List<CategoryDto>>(Messages.ListingNotCompleted);
        }

        public IDataResult<CategoryUpdateDto> GetById(int? id)
        {
            if (id != null)
            {
                var entity = _categoryDal.Get(a => a.Id == (int)id);
                if (entity != null)
                {
                    return new SuccessDataResult<CategoryUpdateDto>(_mapper.Map<CategoryUpdateDto>(entity), Messages.DeletingCompleted);
                }
                return new ErrorDataResult<CategoryUpdateDto>(Messages.GettingNotCompleted);
            }
            return new ErrorDataResult<CategoryUpdateDto>(Messages.GettingNotCompleted);
        }

        public IResult Update(CategoryUpdateDto categoryUpdateDto)
        {
            if (categoryUpdateDto != null)
            {
                _categoryDal.Update(_mapper.Map<Category>(categoryUpdateDto));
                return new SuccessResult(Messages.UpdatingCompleted);
            }
            return new ErrorResult(Messages.UpdatingNotCompleted);
        }
    }
}
