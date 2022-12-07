using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.XCore.Data.Migrations
{
    public partial class RoomCleaningsV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomCleanings_Guests_EmployeeId",
                table: "RoomCleanings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMaintenances_Guests_EmployeeId",
                table: "RoomMaintenances");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCleanings_Employees_EmployeeId",
                table: "RoomCleanings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMaintenances_Employees_EmployeeId",
                table: "RoomMaintenances",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomCleanings_Employees_EmployeeId",
                table: "RoomCleanings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomMaintenances_Employees_EmployeeId",
                table: "RoomMaintenances");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCleanings_Guests_EmployeeId",
                table: "RoomCleanings",
                column: "EmployeeId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomMaintenances_Guests_EmployeeId",
                table: "RoomMaintenances",
                column: "EmployeeId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
