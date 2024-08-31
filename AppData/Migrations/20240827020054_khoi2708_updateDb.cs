using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    /// <inheritdoc />
    public partial class khoi2708_updateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoneyReduce",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "TotalMoney",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "BillStatus",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillStatus",
                table: "Bills");

            migrationBuilder.AddColumn<decimal>(
                name: "MoneyReduce",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PaymentStatus",
                table: "Bills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Bills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMoney",
                table: "Bills",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
