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
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.AddressTitle).IsRequired();
            builder.Property(a => a.AddressTitle).HasMaxLength(15);

            builder.Property(a => a.District).IsRequired();
            builder.Property(a => a.District).HasMaxLength(25);

            builder.Property(a => a.Street).IsRequired();
            builder.Property(a => a.Street).HasMaxLength(25);

            builder.Property(a => a.ApartmentNumber).IsRequired();
            builder.Property(a => a.ApartmentNumber).HasMaxLength(3);

            builder.Property(a => a.ApartmentName).IsRequired(false);
            builder.Property(a => a.ApartmentName).HasMaxLength(25);

            builder.Property(a => a.AddressDescription).IsRequired();
            builder.Property(a => a.AddressDescription).HasMaxLength(50);


            builder.HasOne<User>(a => a.User).WithMany(u => u.Addresses).HasForeignKey(a => a.UserId);



            builder.ToTable("Addresses");
        }
    }
}
