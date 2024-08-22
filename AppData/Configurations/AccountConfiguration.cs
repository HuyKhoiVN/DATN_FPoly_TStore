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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> p)
        {
            p.HasKey(p => p.Id);

            p.HasOne(p => p.Role)
             .WithMany(p => p.Accounts)
             .HasForeignKey(p => p.IdRole);

            p.Property(p => p.Username)
             .IsRequired()
             .HasMaxLength(50); // Giới hạn độ dài của Username

            p.Property(p => p.Password)
             .IsRequired()
             .HasMaxLength(100); // Giới hạn độ dài của Password

            p.Property(p => p.Email)
             .HasMaxLength(100); // Giới hạn độ dài của Email

            p.Property(p => p.ResetTokenExperises)
             .HasDefaultValue(false); // Đặt giá trị mặc định cho ResetTokenExperises

            p.Property(p => p.Dob)
             .IsRequired();

            p.Property(p => p.Gender)
             .HasDefaultValue(true);

            p.Property(p => p.CreatedDate)
             .HasDefaultValueSql("GETDATE()"); // Đặt giá trị mặc định cho CreatedDate là thời gian hiện tại

            p.Property(p => p.ModifiedDate)
             .ValueGeneratedOnUpdate(); // Tự động cập nhật ModifiedDate mỗi khi bản ghi được sửa đổi

            p.Property(p => p.Status)
             .HasDefaultValue(true); // Đặt giá trị mặc định cho Status là true

            p.HasMany(p => p.Address)
             .WithOne(a => a.Account)
             .HasForeignKey(a => a.IdAccount);

            p.HasMany(p => p.Carts)
             .WithOne(c => c.Account)
             .HasForeignKey(c => c.IdAccount);

            p.HasMany(p => p.Bills)
             .WithOne(b => b.Account)
             .HasForeignKey(b => b.IdAccount);
        }

    }
}
