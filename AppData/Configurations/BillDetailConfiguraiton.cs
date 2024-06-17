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
    public class BillDetailConfiguraiton : IEntityTypeConfiguration<BillDetail>
    {
        public void Configure(EntityTypeBuilder<BillDetail> builder)
        {
            builder.HasKey(x => new {x.IdBill, x.IdProductDetail});
            builder.HasOne<Bill>(x => x.Bill).WithMany(x => x.BillDetails).HasForeignKey(x => x.IdBill);
            builder.HasOne<ProductDetail>(x => x.ProductDetail).WithMany(x => x.BillDetails).HasForeignKey(x => x.IdBill);
            
        }
    }
}
