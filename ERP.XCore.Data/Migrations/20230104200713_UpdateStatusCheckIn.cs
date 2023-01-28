using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.XCore.Data.Migrations
{
    public partial class UpdateStatusCheckIn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Payments_PaymentId",
                table: "RoomBookings");

            migrationBuilder.DropIndex(
                name: "IX_RoomBookings_PaymentId",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "RoomBookings");

            migrationBuilder.AlterColumn<double>(
                name: "ChargedAmount",
                table: "RoomBookings",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "RoomBookings",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "RoomBookings",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_StatusId",
                table: "RoomBookings",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Status_StatusId",
                table: "RoomBookings",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomCheckIns_Status_StatusId",
                table: "RoomBookings");

            migrationBuilder.DropIndex(
                name: "IX_RoomCheckIns_StatusId",
                table: "RoomBookings");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "RoomBookings");

            migrationBuilder.AlterColumn<double>(
                name: "ChargedAmount",
                table: "RoomBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "RoomBookings",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PaymentId",
                table: "RoomBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoomCheckIns_PaymentId",
                table: "RoomBookings",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomCheckIns_Payments_PaymentId",
                table: "RoomBookings",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
