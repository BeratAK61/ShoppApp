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
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductAddDto, Product>()
                .ForMember(dest => dest.AddedTime, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(dest=>dest.IsActive,opt=>opt.MapFrom(x=>true))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(x => true));

            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.ModifiedTime, opt => opt.MapFrom(x => DateTime.Now))
                .ReverseMap();

            CreateMap<ProductDto, Product>().ReverseMap();

        }
    }
}
