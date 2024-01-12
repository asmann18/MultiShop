using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiShop.DAL.Migrations
{
    public partial class changeServiceField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Services",
                newName: "IconPath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconPath",
                table: "Services",
                newName: "ImagePath");
        }
    }
}
