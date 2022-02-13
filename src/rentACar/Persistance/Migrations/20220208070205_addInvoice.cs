using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class addInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNo = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RetuRentalEndDaternDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentalDayCount = table.Column<float>(type: "real", nullable: false),
                    TotalFee = table.Column<float>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_InvoiceId",
                table: "Cars",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Invoices_InvoiceId",
                table: "Cars",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Invoices_InvoiceId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Cars_InvoiceId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "Cars");
        }
    }
}
