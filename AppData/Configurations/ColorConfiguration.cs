using AppData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Models.Color>
    {
        public void Configure(EntityTypeBuilder<Models.Color> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(c => c.ProductDetails).WithOne(c => c.Color).HasForeignKey(x => x.IdColor);
        }
    }
}
