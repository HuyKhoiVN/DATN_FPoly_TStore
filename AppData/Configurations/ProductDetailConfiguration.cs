using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Configurations
{
    public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
    {
        public void Configure(EntityTypeBuilder<ProductDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductDetails).HasForeignKey(x => x.IdProduct);
            builder.HasOne(x => x.Size).WithMany(x => x.ProductDetails).HasForeignKey(x => x.IdSize);
            builder.HasOne(x => x.Color).WithMany(x => x.ProductDetails).HasForeignKey(x => x.IdColor);
            builder.HasMany(x => x.CartDetails).WithOne(x => x.ProductDetail).HasForeignKey(x => x.IdProductDetail);
            builder.HasMany(x => x.BillDetails).WithOne(x => x.ProductDetail).HasForeignKey(x => x.IdProductDetail);
        }
    }
}
