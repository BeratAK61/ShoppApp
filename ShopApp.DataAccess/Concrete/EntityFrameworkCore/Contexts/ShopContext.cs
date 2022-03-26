using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApp.DataAccess.Concrete.EntityFrameworkCore.Mappings;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class ShopContext : IdentityDbContext<User,IdentityRole,string>
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AddressMap());
            builder.ApplyConfiguration(new BrandMap());
            builder.ApplyConfiguration(new CartItemMap());
            builder.ApplyConfiguration(new CartMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new OrderItemMap());
            builder.ApplyConfiguration(new OrderMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new UserRefreshTokenMap());

            base.OnModelCreating(builder);
        }
    }
}
