using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Name).HasMaxLength(25);

            builder.Property(u => u.Surname).IsRequired();
            builder.Property(u => u.Surname).HasMaxLength(50);

            builder.Property(u => u.Age).IsRequired();
            builder.Property(u => u.Age).HasMaxLength(2);

            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50);
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.UserName).HasMaxLength(25);
            builder.HasIndex(u => u.UserName).IsUnique();



            builder.HasOne<Cart>(u => u.Cart).WithOne(c => c.User).HasForeignKey<Cart>(c => c.UserId);


        }
    }
}
