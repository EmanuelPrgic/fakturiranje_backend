using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedFakture3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usluge");

            migrationBuilder.DropColumn(
                name: "UkupanIznos",
                table: "ZaglavljeRacuna");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UkupanIznos",
                table: "ZaglavljeRacuna",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FakturnaVrijednost",
                table: "StavkeRacuna",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IznosPdv",
                table: "StavkeRacuna",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IznosRabata",
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

            migrationBuilder.AddColumn<int>(
                name: "UkupanIznos",
                table: "StavkeRacuna",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usluge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StavkeRacunaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CijenaDeviza = table.Column<int>(type: "INTEGER", nullable: false),
                    CijenaKM = table.Column<int>(type: "INTEGER", nullable: false),
                    Naziv = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usluge_StavkeRacuna_StavkeRacunaId",
                        column: x => x.StavkeRacunaId,
                        principalTable: "StavkeRacuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usluge_StavkeRacunaId",
                table: "Usluge",
                column: "StavkeRacunaId");
        }
    }
}
