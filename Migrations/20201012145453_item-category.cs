using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWeb.Migrations
{
    public partial class itemcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UsersTb",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "UsersTb",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "CategoriesTb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsTb",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsTb_CategoriesTb_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoriesTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemsTb_CategoryId",
                table: "ItemsTb",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemsTb");

            migrationBuilder.DropTable(
                name: "CategoriesTb");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "UsersTb");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "UsersTb",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
