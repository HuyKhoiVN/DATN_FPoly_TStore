﻿// <auto-generated />
using System;
using AppData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AppData.Migrations
{
    [DbContext(typeof(TStoreDb))]
    [Migration("20240827020054_khoi2708_updateDb")]
    partial class khoi2708_updateDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AppData.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<Guid>("IdRole")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("ResetTokenExperises")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("TokenResetPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("AppData.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("DefaultAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("IdAccount")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Ward")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdAccount");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("AppData.Models.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BillStatus")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdAccount")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPaymentMethod")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ShipFee")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ShipmentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdAccount");

                    b.HasIndex("IdPaymentMethod");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("AppData.Models.BillDetail", b =>
                {
                    b.Property<Guid>("IdBill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProductDetail")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("IdBill", "IdProductDetail");

                    b.HasIndex("IdProductDetail");

                    b.ToTable("BillDetails");
                });

            modelBuilder.Entity("AppData.Models.Cart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdAccount")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdAccount");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("AppData.Models.CartDetail", b =>
                {
                    b.Property<Guid>("IdCart")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProductDetail")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdCart", "IdProductDetail");

                    b.HasIndex("IdProductDetail");

                    b.ToTable("CartDetails");
                });

            modelBuilder.Entity("AppData.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AppData.Models.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ColorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("AppData.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdPorduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdPorduct");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("AppData.Models.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCategory")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiledDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Tittle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.ToTable("News");
                });

            modelBuilder.Entity("AppData.Models.PaymentMethod", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<decimal>("TotalMoney")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentMethods");
                });

            modelBuilder.Entity("AppData.Models.Producer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("AppData.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<Guid>("IdProducer")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProductCategory")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Rating")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .HasDatabaseName("IX_Product_Code");

                    b.HasIndex("IdProducer");

                    b.HasIndex("IdProductCategory");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_Product_Name");

                    b.HasIndex("Price")
                        .HasDatabaseName("IX_Product_Price");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("AppData.Models.ProductCatergory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ProductCatergories");
                });

            modelBuilder.Entity("AppData.Models.ProductDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdColor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdProduct")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSize")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiledDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdColor");

                    b.HasIndex("IdProduct");

                    b.HasIndex("IdSize");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("AppData.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("AppData.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SizeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("AppData.Models.Voucher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("DiscountAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdBill")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<double>("Value")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("IdBill");

                    b.ToTable("Vouchers");
                });

            modelBuilder.Entity("AppData.Models.Account", b =>
                {
                    b.HasOne("AppData.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AppData.Models.Address", b =>
                {
                    b.HasOne("AppData.Models.Account", "Account")
                        .WithMany("Address")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("AppData.Models.Bill", b =>
                {
                    b.HasOne("AppData.Models.Account", "Account")
                        .WithMany("Bills")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.PaymentMethod", "PaymentMethod")
                        .WithMany("Bills")
                        .HasForeignKey("IdPaymentMethod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("PaymentMethod");
                });

            modelBuilder.Entity("AppData.Models.BillDetail", b =>
                {
                    b.HasOne("AppData.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdBill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.ProductDetail", "ProductDetail")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdProductDetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("AppData.Models.Cart", b =>
                {
                    b.HasOne("AppData.Models.Account", "Account")
                        .WithMany("Carts")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("AppData.Models.CartDetail", b =>
                {
                    b.HasOne("AppData.Models.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("IdCart")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.ProductDetail", "ProductDetail")
                        .WithMany("CartDetails")
                        .HasForeignKey("IdProductDetail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("ProductDetail");
                });

            modelBuilder.Entity("AppData.Models.Image", b =>
                {
                    b.HasOne("AppData.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("IdPorduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("AppData.Models.News", b =>
                {
                    b.HasOne("AppData.Models.Category", "Category")
                        .WithMany("News")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AppData.Models.Product", b =>
                {
                    b.HasOne("AppData.Models.Producer", "Producer")
                        .WithMany("Products")
                        .HasForeignKey("IdProducer")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.ProductCatergory", "ProductCatergory")
                        .WithMany("Products")
                        .HasForeignKey("IdProductCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producer");

                    b.Navigation("ProductCatergory");
                });

            modelBuilder.Entity("AppData.Models.ProductDetail", b =>
                {
                    b.HasOne("AppData.Models.Color", "Color")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IdColor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppData.Models.Size", "Size")
                        .WithMany("ProductDetails")
                        .HasForeignKey("IdSize")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Color");

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("AppData.Models.Voucher", b =>
                {
                    b.HasOne("AppData.Models.Bill", "Bill")
                        .WithMany("Vouchers")
                        .HasForeignKey("IdBill")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");
                });

            modelBuilder.Entity("AppData.Models.Account", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Bills");

                    b.Navigation("Carts");
                });

            modelBuilder.Entity("AppData.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("Vouchers");
                });

            modelBuilder.Entity("AppData.Models.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("AppData.Models.Category", b =>
                {
                    b.Navigation("News");
                });

            modelBuilder.Entity("AppData.Models.Color", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("AppData.Models.PaymentMethod", b =>
                {
                    b.Navigation("Bills");
                });

            modelBuilder.Entity("AppData.Models.Producer", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("AppData.Models.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("AppData.Models.ProductCatergory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("AppData.Models.ProductDetail", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("AppData.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("AppData.Models.Size", b =>
                {
                    b.Navigation("ProductDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
