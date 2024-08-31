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
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Account).WithMany(c => c.Carts).HasForeignKey(c => c.IdAccount);
            builder.HasMany(c => c.CartDetails).WithOne(c => c.Cart).HasForeignKey(c => c.IdCart);
        }
    }
}
