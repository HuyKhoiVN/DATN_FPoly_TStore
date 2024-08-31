using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Cart).WithMany(c => c.CartDetails).HasForeignKey(c => c.IdCart);
            builder.HasOne(c => c.ProductDetail).WithMany(c => c.CartDetails).HasForeignKey(c => c.IdProductDetail);
        }
    }
}
