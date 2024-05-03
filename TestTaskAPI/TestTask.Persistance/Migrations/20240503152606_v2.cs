using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestTask.Persistance.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgLink",
                table: "Products",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "string");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImgLink",
                table: "Products",
                type: "string",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "string",
                oldNullable: true);
        }
    }
}
