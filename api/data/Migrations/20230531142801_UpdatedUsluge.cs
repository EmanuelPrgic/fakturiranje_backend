using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUsluge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FakturnaVrijednost",
                table: "StavkeRacuna",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IznosPdv",
                table: "StavkeRacuna",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "IznosRabata",
                table: "StavkeRacuna",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Osnovica",
                table: "StavkeRacuna",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "UkupanIznos",
                table: "StavkeRacuna",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FakturnaVrijednost",
                table: "StavkeRacuna");

            migrationBuilder.DropColumn(
                name: "IznosPdv",
                table: "StavkeRacuna");

            migrationBuilder.DropColumn(
                name: "IznosRabata",
                table: "StavkeRacuna");

            migrationBuilder.DropColumn(
                name: "Osnovica",
                table: "StavkeRacuna");

            migrationBuilder.DropColumn(
                name: "UkupanIznos",
                table: "StavkeRacuna");
        }
    }
}
