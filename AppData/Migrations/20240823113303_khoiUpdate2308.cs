using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    /// <inheritdoc />
    public partial class khoiUpdate2308 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_ProductDetails_IdBill",
                table: "BillDetails");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_IdProductDetail",
                table: "BillDetails",
                column: "IdProductDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_ProductDetails_IdProductDetail",
                table: "BillDetails",
                column: "IdProductDetail",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillDetails_ProductDetails_IdProductDetail",
                table: "BillDetails");

            migrationBuilder.DropIndex(
                name: "IX_BillDetails_IdProductDetail",
                table: "BillDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_BillDetails_ProductDetails_IdBill",
                table: "BillDetails",
                column: "IdBill",
                principalTable: "ProductDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
