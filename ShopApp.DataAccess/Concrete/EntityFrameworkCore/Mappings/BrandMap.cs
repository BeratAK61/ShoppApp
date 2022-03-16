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
    public class BrandMap : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id).ValueGeneratedOnAdd();

            builder.Property(b => b.Name).IsRequired();
            builder.Property(b => b.Name).HasMaxLength(25);

            builder.Property(b => b.Description).IsRequired(false);
            builder.Property(b => b.Description).HasMaxLength(25);


            builder.ToTable("Brands");
        }
    }
}
