using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWeb.Migrations
{
    public partial class ImageNameSalePurchasePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ItemsTb");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "ItemsTb",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SalePurchasePrice",
                table: "ItemsTb",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SalesPrice",
                table: "ItemsTb",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "ItemsTb");

            migrationBuilder.DropColumn(
                name: "SalePurchasePrice",
                table: "ItemsTb");

            migrationBuilder.DropColumn(
                name: "SalesPrice",
                table: "ItemsTb");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "ItemsTb",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
