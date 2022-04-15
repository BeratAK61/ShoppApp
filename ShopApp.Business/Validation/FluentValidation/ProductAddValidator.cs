using FluentValidation;
using ShopApp.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.Validation.FluentValidation
{
    public class ProductAddValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddValidator()
        {

            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün Adı alanı boş geçilmemelidir");
            RuleFor(p => p.Name).MaximumLength(25).WithMessage("Ürün Adı en fazla 25 karakterden oluşmalıdır");

            RuleFor(p => p.Description).NotEmpty().WithMessage("Ürün Açıklaması alanı boş geçilmemelidir");
            RuleFor(p => p.Description).MaximumLength(25).WithMessage("Ürün Açıklaması en fazla 25 karakterden oluşmalıdır");

            RuleFor(p => p.Quantity).GreaterThan(0).WithMessage("Ürün Miktarı 0'dan büyük olmalıdır");

            RuleFor(p => p.Price).NotEmpty().WithMessage("Ürün Fiyatı alanı boş geçilmemelidir");
            RuleFor(p => p.Price).GreaterThan(0).WithMessage("Ürün Fiyatı 0'dan büyük olmalıdır");
            
            RuleFor(p => p.Barcode).MinimumLength(2).WithMessage("Barkod alanı en az 2 haneli olmalıdır");
            RuleFor(p => p.Barcode).MaximumLength(25).WithMessage("Barkod alanı en fazla 25 haneli olmalıdır");

            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Ürün Kategorisi alanı boş geçilmemelidir");

            RuleFor(p => p.BrandId).NotEmpty().WithMessage("Ürün Markası alanı boş geçilmemelidir");

        }
    }
}
