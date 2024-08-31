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
	public class AddressConfiguration : IEntityTypeConfiguration<Address>
	{
		public void Configure(EntityTypeBuilder<Address> builder)
		{
			builder.HasKey(c => c.Id);

            // Cấu hình has one with many
			builder.HasOne(c => c.Account).WithMany(c => c.Address).HasForeignKey(c => c.IdAccount);

            builder.Property(p => p.City)
            .IsRequired()
            .HasMaxLength(100);

            builder.Property(p => p.District)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.Ward)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(p => p.DefaultAddress)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Status)
                .IsRequired();
        }
	}
}
