using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    /// <inheritdoc />
    public partial class KhoiUpdateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ProductDetails_IdPorductDetail",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_Producers_IdProducer",
                table: "ProductDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetails_ProductCatergories_IdProductCategory",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_IdProducer",
                table: "ProductDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetails_IdProductCategory",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "IdProducer",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "IdProductCategory",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "ProductDetails");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Vouchers",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Vouchers",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "PaymentMethods",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "PaymentMethods",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "IdPorductDetail",
                table: "Images",
                newName: "IdPorduct");

            migrationBuilder.RenameIndex(
                name: "IX_Images_IdPorductDetail",
                table: "Images",
                newName: "IX_Images_IdPorduct");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Carts",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Carts",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Update_date",
                table: "CartDetails",
                newName: "ModifiedDate");

            migrationBuilder.RenameColumn(
                name: "Create_date",
                table: "CartDetails",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "CretaedDate",
                table: "Bills",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdProducer",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdProductCategory",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalMoney",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShipmentDate",
                table: "Bills",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Bills",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "MoneyReduce",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Ward",
                table: "Addresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "Addresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DefaultAddress",
                table: "Addresses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Accounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "ResetTokenExperises",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Code",
                table: "Products",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Price",
                table: "Products",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdProducer",
                table: "Products",
                column: "IdProducer");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IdProductCategory",
                table: "Products",
                column: "IdProductCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Products_IdPorduct",
                table: "Images",
                column: "IdPorduct",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Producers_IdProducer",
                table: "Products",
                column: "IdProducer",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCatergories_IdProductCategory",
                table: "Products",
                column: "IdProductCategory",
                principalTable: "ProductCatergories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Products_IdPorduct",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Producers_IdProducer",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCatergories_IdProductCategory",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Product_Code",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Product_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Product_Price",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdProducer",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_IdProductCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdProducer",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdProductCategory",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Vouchers",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Vouchers",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "PaymentMethods",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "PaymentMethods",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "IdPorduct",
                table: "Images",
                newName: "IdPorductDetail");

            migrationBuilder.RenameIndex(
                name: "IX_Images_IdPorduct",
                table: "Images",
                newName: "IX_Images_IdPorductDetail");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Carts",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Carts",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "CartDetails",
                newName: "Update_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "CartDetails",
                newName: "Create_date");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Bills",
                newName: "CretaedDate");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IdProducer",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdProductCategory",
                table: "ProductDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ProductDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "ProductDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalMoney",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ShipmentDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PaymentDate",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MoneyReduce",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Code",
                table: "Bills",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Ward",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "District",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DefaultAddress",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "Status",
                table: "Accounts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ResetTokenExperises",
                table: "Accounts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "Accounts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Accounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IdProducer",
                table: "ProductDetails",
                column: "IdProducer");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetails_IdProductCategory",
                table: "ProductDetails",
                column: "IdProductCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ProductDetails_IdPorductDetail",
                table: "Images",
                column: "IdPorductDetail",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_Producers_IdProducer",
                table: "ProductDetails",
                column: "IdProducer",
                principalTable: "Producers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetails_ProductCatergories_IdProductCategory",
                table: "ProductDetails",
                column: "IdProductCategory",
                principalTable: "ProductCatergories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
