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
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCatergory>
    {
        public void Configure(EntityTypeBuilder<ProductCatergory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Products).WithOne(x => x.ProductCatergory).HasForeignKey(x => x.IdProductCategory);
        }
    }
}
