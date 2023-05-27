using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPartners : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usluga_StavkeRacuna_StavkeRacunaId",
                table: "Usluga");

            migrationBuilder.DropForeignKey(
                name: "FK_ZaglavljeRacuna_Partner_PartnerId",
                table: "ZaglavljeRacuna");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usluga",
                table: "Usluga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partner",
                table: "Partner");

            migrationBuilder.RenameTable(
                name: "Usluga",
                newName: "Usluge");

            migrationBuilder.RenameTable(
                name: "Partner",
                newName: "Partneri");

            migrationBuilder.RenameIndex(
                name: "IX_Usluga_StavkeRacunaId",
                table: "Usluge",
                newName: "IX_Usluge_StavkeRacunaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usluge",
                table: "Usluge",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partneri",
                table: "Partneri",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usluge_StavkeRacuna_StavkeRacunaId",
                table: "Usluge",
                column: "StavkeRacunaId",
                principalTable: "StavkeRacuna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZaglavljeRacuna_Partneri_PartnerId",
                table: "ZaglavljeRacuna",
                column: "PartnerId",
                principalTable: "Partneri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usluge_StavkeRacuna_StavkeRacunaId",
                table: "Usluge");

            migrationBuilder.DropForeignKey(
                name: "FK_ZaglavljeRacuna_Partneri_PartnerId",
                table: "ZaglavljeRacuna");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usluge",
                table: "Usluge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partneri",
                table: "Partneri");

            migrationBuilder.RenameTable(
                name: "Usluge",
                newName: "Usluga");

            migrationBuilder.RenameTable(
                name: "Partneri",
                newName: "Partner");

            migrationBuilder.RenameIndex(
                name: "IX_Usluge_StavkeRacunaId",
                table: "Usluga",
                newName: "IX_Usluga_StavkeRacunaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usluga",
                table: "Usluga",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partner",
                table: "Partner",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usluga_StavkeRacuna_StavkeRacunaId",
                table: "Usluga",
                column: "StavkeRacunaId",
                principalTable: "StavkeRacuna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ZaglavljeRacuna_Partner_PartnerId",
                table: "ZaglavljeRacuna",
                column: "PartnerId",
                principalTable: "Partner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
