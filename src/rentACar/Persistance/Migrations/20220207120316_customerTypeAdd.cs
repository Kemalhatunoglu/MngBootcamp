using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class customerTypeAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorporateCustomerId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndividualCustomerId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaintainEndDate",
                table: "Cars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaintainStartDate",
                table: "Cars",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CorporateCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateCustomers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalIdentity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualCustomers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_CorporateCustomerId",
                table: "Rentals",
                column: "CorporateCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_IndividualCustomerId",
                table: "Rentals",
                column: "IndividualCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_CorporateCustomers_CorporateCustomerId",
                table: "Rentals",
                column: "CorporateCustomerId",
                principalTable: "CorporateCustomers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_IndividualCustomers_IndividualCustomerId",
                table: "Rentals",
                column: "IndividualCustomerId",
                principalTable: "IndividualCustomers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_CorporateCustomers_CorporateCustomerId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_IndividualCustomers_IndividualCustomerId",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "CorporateCustomers");

            migrationBuilder.DropTable(
                name: "IndividualCustomers");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_CorporateCustomerId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_IndividualCustomerId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "CorporateCustomerId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "IndividualCustomerId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "MaintainEndDate",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MaintainStartDate",
                table: "Cars");
        }
    }
}
