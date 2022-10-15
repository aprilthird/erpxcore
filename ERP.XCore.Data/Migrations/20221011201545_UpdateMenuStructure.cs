using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.XCore.Data.Migrations
{
    public partial class UpdateMenuStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RouteUrl",
                table: "SubModules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteUrl",
                table: "SubModules");
        }
    }
}
