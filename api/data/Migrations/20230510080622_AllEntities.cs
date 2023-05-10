using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AllEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partneri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", nullable: true),
                    Adresa = table.Column<string>(type: "TEXT", nullable: true),
                    Mjesto = table.Column<string>(type: "TEXT", nullable: true),
                    BrojPoste = table.Column<int>(type: "INTEGER", nullable: false),
                    Mb = table.Column<int>(type: "INTEGER", nullable: false),
                    Pdv = table.Column<int>(type: "INTEGER", nullable: false),
                    BankaJedan = table.Column<string>(type: "TEXT", nullable: true),
                    BankaDva = table.Column<string>(type: "TEXT", nullable: true),
                    BankaTri = table.Column<string>(type: "TEXT", nullable: true),
                    Swift = table.Column<string>(type: "TEXT", nullable: true),
                    Tip = table.Column<string>(type: "TEXT", nullable: true),
                    Drzava = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partneri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usluga",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naziv = table.Column<string>(type: "TEXT", nullable: true),
                    CijenaDeviza = table.Column<int>(type: "INTEGER", nullable: false),
                    CijenaKM = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usluga", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ZaglavljeRacuna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BrojRacuna = table.Column<int>(type: "INTEGER", nullable: false),
                    DatumIsporuke = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DatumDokumenta = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DatumDospijeca = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Opis = table.Column<string>(type: "TEXT", nullable: true),
                    MjestoIzdavanja = table.Column<string>(type: "TEXT", nullable: true),
                    DatumIzdavanja = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FiskalniBroj = table.Column<int>(type: "INTEGER", nullable: false),
                    KupacId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tecaj = table.Column<int>(type: "INTEGER", nullable: false),
                    Napomena = table.Column<string>(type: "TEXT", nullable: true),
                    UkupanIznos = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaglavljeRacuna", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StavkeRacuna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Opis = table.Column<string>(type: "TEXT", nullable: true),
                    Kolicina = table.Column<int>(type: "INTEGER", nullable: false),
                    CijenaDeviza = table.Column<int>(type: "INTEGER", nullable: false),
                    CijenaKM = table.Column<int>(type: "INTEGER", nullable: false),
                    FakturnaVrijednost = table.Column<int>(type: "INTEGER", nullable: false),
                    Rabat = table.Column<int>(type: "INTEGER", nullable: false),
                    IznosRabata = table.Column<int>(type: "INTEGER", nullable: false),
                    Pdv = table.Column<int>(type: "INTEGER", nullable: false),
                    Vrijednost = table.Column<int>(type: "INTEGER", nullable: false),
                    ZaglavljeRacunaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeRacuna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkeRacuna_ZaglavljeRacuna_ZaglavljeRacunaId",
                        column: x => x.ZaglavljeRacunaId,
                        principalTable: "ZaglavljeRacuna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRacuna_ZaglavljeRacunaId",
                table: "StavkeRacuna",
                column: "ZaglavljeRacunaId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partneri");

            migrationBuilder.DropTable(
                name: "StavkeRacuna");

            migrationBuilder.DropTable(
                name: "Usluga");

            migrationBuilder.DropTable(
                name: "ZaglavljeRacuna");
        }
    }
}
