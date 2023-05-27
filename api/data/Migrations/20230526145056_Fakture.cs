using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Fakture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vrijednost",
                table: "StavkeRacuna",
                newName: "UkupanIznos");

            migrationBuilder.AddColumn<int>(
                name: "IznosPdv",
                table: "StavkeRacuna",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Osnovica",
                table: "StavkeRacuna",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IznosPdv",
                table: "StavkeRacuna");

            migrationBuilder.DropColumn(
                name: "Osnovica",
                table: "StavkeRacuna");

            migrationBuilder.RenameColumn(
                name: "UkupanIznos",
                table: "StavkeRacuna",
                newName: "Vrijednost");
        }
    }
}
