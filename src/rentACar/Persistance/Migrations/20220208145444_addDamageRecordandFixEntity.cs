using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    public partial class addDamageRecordandFixEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeliveryCityId",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentedCityId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "FinishKm",
                table: "Cars",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "StartingKm",
                table: "Cars",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "DamageRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    DamageExp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DamageRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DamageRecords_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DamageRecords_CarId",
                table: "DamageRecords",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DamageRecords");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "DeliveryCityId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "RentedCityId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "FinishKm",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "StartingKm",
                table: "Cars");
        }
    }
}
