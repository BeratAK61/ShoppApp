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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(25);

            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(50);

            builder.Property(p => p.Quantity).HasDefaultValue(5);

            builder.Property(p => p.Image).IsRequired(false);

            builder.Property(p => p.Barcode).HasMaxLength(13);


            builder.HasOne<Category>(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);

            builder.HasOne<Brand>(p => p.Brand).WithMany(b => b.Products).HasForeignKey(p => p.BrandId);


            builder.ToTable("Products");

        }
    }
}
