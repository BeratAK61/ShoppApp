using AutoMapper;
using ShopApp.Entities.Concrete;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Mapping.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryAddDto, Category>()
                .ForMember(dest => dest.AddedTime, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => true));

            CreateMap<CategoryUpdateDto, Category>()
                .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now));

            CreateMap<CategoryDto, Category>().ReverseMap();

        }
    }
}
