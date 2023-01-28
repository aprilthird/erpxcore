using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.XCore.Data.Migrations
{
    public partial class AddFeesAndFeeTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingCompanions_Guests_GuestId",
                table: "RoomBookingCompanions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingCompanions_RoomBookings_RoomBookingId",
                table: "RoomBookingCompanions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingDetails_PaymentDetails_PaymentDetailId",
                table: "RoomBookingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingDetails_RoomBookings_RoomBookingId",
                table: "RoomBookingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Guests_GuestId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_PaymentMethods_PaymentMethodId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_RoomBookings_RelatedBookingId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Status_StatusId",
                table: "RoomBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBookings",
                table: "RoomBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBookingDetails",
                table: "RoomBookingDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBookingCompanions",
                table: "RoomBookingCompanions");

            migrationBuilder.RenameTable(
                name: "RoomBookings",
                newName: "RoomBookings");

            migrationBuilder.RenameTable(
                name: "RoomBookingDetails",
                newName: "RoomBookingDetails");

            migrationBuilder.RenameTable(
                name: "RoomBookingCompanions",
                newName: "RoomBookingCompanions");

            migrationBuilder.RenameColumn(
                name: "RelatedBookingId",
                table: "RoomBookings",
                newName: "RelatedBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_StatusId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_RoomId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_RelatedBookingId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_RelatedBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_PaymentMethodId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_GuestId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_GuestId");

            migrationBuilder.RenameColumn(
                name: "RoomBookingId",
                table: "RoomBookingDetails",
                newName: "RoomBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookingDetails_RoomBookingId",
                table: "RoomBookingDetails",
                newName: "IX_RoomBookingDetails_RoomBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookingDetails_PaymentDetailId",
                table: "RoomBookingDetails",
                newName: "IX_RoomBookingDetails_PaymentDetailId");

            migrationBuilder.RenameColumn(
                name: "RoomBookingId",
                table: "RoomBookingCompanions",
                newName: "RoomBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookingCompanions_RoomBookingId",
                table: "RoomBookingCompanions",
                newName: "IX_RoomBookingCompanions_RoomBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookingCompanions_GuestId",
                table: "RoomBookingCompanions",
                newName: "IX_RoomBookingCompanions_GuestId");

            migrationBuilder.AlterColumn<Guid>(
                name: "StatusId",
                table: "RoomBookings",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "FeeId",
                table: "RoomBookings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBookings",
                table: "RoomBookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBookingDetails",
                table: "RoomBookingDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBookingCompanions",
                table: "RoomBookingCompanions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FeeTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeeTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeeTypes_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fees_FeeTypes_FeeTypeId",
                        column: x => x.FeeTypeId,
                        principalTable: "FeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fees_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fees_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomBookings_FeeId",
                table: "RoomBookings",
                column: "FeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_FeeTypeId",
                table: "Fees",
                column: "FeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_RoomTypeId",
                table: "Fees",
                column: "RoomTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fees_StatusId",
                table: "Fees",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FeeTypes_CurrencyId",
                table: "FeeTypes",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingCompanions_Guests_GuestId",
                table: "RoomBookingCompanions",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingCompanions_RoomBookings_RoomBookingId",
                table: "RoomBookingCompanions",
                column: "RoomBookingId",
                principalTable: "RoomBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingDetails_PaymentDetails_PaymentDetailId",
                table: "RoomBookingDetails",
                column: "PaymentDetailId",
                principalTable: "PaymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingDetails_RoomBookings_RoomBookingId",
                table: "RoomBookingDetails",
                column: "RoomBookingId",
                principalTable: "RoomBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Fees_FeeId",
                table: "RoomBookings",
                column: "FeeId",
                principalTable: "Fees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Guests_GuestId",
                table: "RoomBookings",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_PaymentMethods_PaymentMethodId",
                table: "RoomBookings",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_RoomBookings_RelatedBookingId",
                table: "RoomBookings",
                column: "RelatedBookingId",
                principalTable: "RoomBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_RoomBookingCompanions_Guests_GuestId",
                table: "RoomBookingCompanions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingCompanions_RoomBookings_RoomBookingId",
                table: "RoomBookingCompanions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingDetails_PaymentDetails_PaymentDetailId",
                table: "RoomBookingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookingDetails_RoomBookings_RoomBookingId",
                table: "RoomBookingDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Fees_FeeId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Guests_GuestId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_PaymentMethods_PaymentMethodId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_RoomBookings_RelatedBookingId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_RoomBookings_Status_StatusId",
                table: "RoomBookings");

            migrationBuilder.DropTable(
                name: "Fees");

            migrationBuilder.DropTable(
                name: "FeeTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBookings",
                table: "RoomBookings");

            migrationBuilder.DropIndex(
                name: "IX_RoomBookings_FeeId",
                table: "RoomBookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBookingDetails",
                table: "RoomBookingDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomBookingCompanions",
                table: "RoomBookingCompanions");

            migrationBuilder.DropColumn(
                name: "FeeId",
                table: "RoomBookings");

            migrationBuilder.RenameTable(
                name: "RoomBookings",
                newName: "RoomBookings");

            migrationBuilder.RenameTable(
                name: "RoomBookingDetails",
                newName: "RoomBookingDetails");

            migrationBuilder.RenameTable(
                name: "RoomBookingCompanions",
                newName: "RoomBookingCompanions");

            migrationBuilder.RenameColumn(
                name: "RelatedBookingId",
                table: "RoomBookings",
                newName: "RelatedBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_StatusId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_RoomId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_RelatedBookingId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_RelatedBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_PaymentMethodId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_PaymentMethodId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookings_GuestId",
                table: "RoomBookings",
                newName: "IX_RoomBookings_GuestId");

            migrationBuilder.RenameColumn(
                name: "RoomBookingId",
                table: "RoomBookingDetails",
                newName: "RoomBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookingDetails_RoomBookingId",
                table: "RoomBookingDetails",
                newName: "IX_RoomBookingDetails_RoomBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookingDetails_PaymentDetailId",
                table: "RoomBookingDetails",
                newName: "IX_RoomBookingDetails_PaymentDetailId");

            migrationBuilder.RenameColumn(
                name: "RoomBookingId",
                table: "RoomBookingCompanions",
                newName: "RoomBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookingCompanions_RoomBookingId",
                table: "RoomBookingCompanions",
                newName: "IX_RoomBookingCompanions_RoomBookingId");

            migrationBuilder.RenameIndex(
                name: "IX_RoomBookingCompanions_GuestId",
                table: "RoomBookingCompanions",
                newName: "IX_RoomBookingCompanions_GuestId");

            migrationBuilder.AlterColumn<Guid>(
                name: "StatusId",
                table: "RoomBookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBookings",
                table: "RoomBookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBookingDetails",
                table: "RoomBookingDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomBookingCompanions",
                table: "RoomBookingCompanions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingCompanions_Guests_GuestId",
                table: "RoomBookingCompanions",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingCompanions_RoomBookings_RoomBookingId",
                table: "RoomBookingCompanions",
                column: "RoomBookingId",
                principalTable: "RoomBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingDetails_PaymentDetails_PaymentDetailId",
                table: "RoomBookingDetails",
                column: "PaymentDetailId",
                principalTable: "PaymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookingDetails_RoomBookings_RoomBookingId",
                table: "RoomBookingDetails",
                column: "RoomBookingId",
                principalTable: "RoomBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Guests_GuestId",
                table: "RoomBookings",
                column: "GuestId",
                principalTable: "Guests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_PaymentMethods_PaymentMethodId",
                table: "RoomBookings",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_RoomBookings_RelatedBookingId",
                table: "RoomBookings",
                column: "RelatedBookingId",
                principalTable: "RoomBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Rooms_RoomId",
                table: "RoomBookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoomBookings_Status_StatusId",
                table: "RoomBookings",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
