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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Producer).WithMany(x => x.Products).HasForeignKey(x => x.IdProducer);
            builder.HasOne(x => x.ProductCatergory).WithMany(x => x.Products).HasForeignKey(x => x.IdProductCategory);

            // Cấu hình chi tiết cho các property

            // Tên sp bắt buộc, yêu cầu tối đa 100 ký tự
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            // Bắt buộc nhập Code
            builder.Property(p => p.Code).HasMaxLength(20).IsRequired();

            // Kiểu dữ liệu giá tiền, bắt buộc nhập
            builder.Property(e => e.Price).HasColumnType("decimal(18,2)").IsRequired();

            // Mô tả tối đa 500
            builder.Property(p => p.Description).HasMaxLength(500);

            // Đánh index cho các cột để tăng tốc độ tìm kiếm
            builder.HasIndex(e => e.Name).HasDatabaseName("IX_Product_Name");
            builder.HasIndex(e => e.Code).HasDatabaseName("IX_Product_Code");
            builder.HasIndex(e => e.Price).HasDatabaseName("IX_Product_Price");
        }
    }
}
