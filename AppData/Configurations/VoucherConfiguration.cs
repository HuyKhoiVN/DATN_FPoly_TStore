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
	public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
	{
		public void Configure(EntityTypeBuilder<Voucher> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne<Bill>(x => x.Bill).WithMany(x => x.Vouchers).HasForeignKey(x => x.IdBill);
		}
	}
}
