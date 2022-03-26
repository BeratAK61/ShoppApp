using Autofac;
using ShopApp.Business.Abstract;
using ShopApp.Business.Concrete;
using ShopApp.DataAccess.Abstract;
using ShopApp.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AddressManager>().As<IAddressService>().SingleInstance();
            builder.RegisterType<AuthenticationManager>().As<IAuthenticationService>().SingleInstance();
            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<CartItemManager>().As<ICartItemService>().SingleInstance();
            builder.RegisterType<CartManager>().As<ICartService>().SingleInstance();
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<OrderItemManager>().As<IOrderItemService>().SingleInstance();
            builder.RegisterType<OrderManager>().As<IOrderService>().SingleInstance();
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<TokenManager>().As<ITokenService>().SingleInstance();
            builder.RegisterType<UserRefreshTokenManager>().As<IUserRefreshTokenService>().SingleInstance();


            builder.RegisterType<EfCoreAddressDal>().As<IAddressDal>().SingleInstance();
            builder.RegisterType<EfCoreBrandDal>().As<IBrandDal>().SingleInstance();
            builder.RegisterType<EfCoreCartItemDal>().As<ICartItemDal>().SingleInstance();
            builder.RegisterType<EfCoreCartDal>().As<ICartDal>().SingleInstance();
            builder.RegisterType<EfCoreCategoryDal>().As<ICategoryDal>().SingleInstance();
            builder.RegisterType<EfCoreOrderItemDal>().As<IOrderItemDal>().SingleInstance();
            builder.RegisterType<EfCoreOrderDal>().As<IOrderDal>().SingleInstance();
            builder.RegisterType<EfCoreProductDal>().As<IProductDal>().SingleInstance();
            builder.RegisterType<EfCoreUserRefreshTokenDal>().As<IUserRefreshTokenDal>().SingleInstance();
        }
    }
}
