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
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id).ValueGeneratedOnAdd();

            builder.Property(o => o.Note).IsRequired(false);
            builder.Property(o => o.Note).HasMaxLength(100);

            builder.Property(o => o.OrderNumber).IsRequired(true);
            builder.Property(o => o.OrderNumber).HasMaxLength(25);


            builder.ToTable("Orders");
        }
    }
}
