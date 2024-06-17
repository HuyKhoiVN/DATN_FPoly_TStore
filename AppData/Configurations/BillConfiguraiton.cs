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
    public class OrderConfiguraiton : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne<Account>(x => x.Account).WithMany(x => x.Bills).HasForeignKey(x => x.IdAccount);
            builder.HasOne<PaymentMethod>(x => x.PaymentMethod).WithMany(x => x.Bills).HasForeignKey(x => x.IdPaymentMethod);
        }
    }
}
