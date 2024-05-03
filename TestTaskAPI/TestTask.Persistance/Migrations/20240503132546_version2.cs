using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.Persistance.Migrations
{
    public partial class version2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgLink",
                table: "Products",
                type: "string",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<bool>(
                name: "Access",
                table: "Coins",
                type: "bool",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgLink",
                table: "Products",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "string");

            migrationBuilder.AlterColumn<bool>(
                name: "Access",
                table: "Coins",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bool");
        }
    }
}
