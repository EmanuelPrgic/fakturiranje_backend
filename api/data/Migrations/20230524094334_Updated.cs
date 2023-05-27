using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StavkeRacuna_ZaglavljeRacunaId",
                table: "StavkeRacuna");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partneri",
                table: "Partneri");

            migrationBuilder.RenameTable(
                name: "Partneri",
                newName: "Partner");

            migrationBuilder.RenameColumn(
                name: "KupacId",
                table: "ZaglavljeRacuna",
                newName: "PartnerId");

            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
                table: "Usluga",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StavkeRacunaId",
                table: "Usluga",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ZaglavljeRacunaId",
                table: "Usluga",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partner",
                table: "Partner",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ZaglavljeRacuna_PartnerId",
                table: "ZaglavljeRacuna",
                column: "PartnerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usluga_PartnerId",
                table: "Usluga",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluga_StavkeRacunaId",
                table: "Usluga",
                column: "StavkeRacunaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluga_ZaglavljeRacunaId",
                table: "Usluga",
                column: "ZaglavljeRacunaId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRacuna_ZaglavljeRacunaId",
                table: "StavkeRacuna",
                column: "ZaglavljeRacunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usluga_Partner_PartnerId",
                table: "Usluga",
                column: "PartnerId",
                principalTable: "Partner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usluga_StavkeRacuna_StavkeRacunaId",
                table: "Usluga",
                column: "StavkeRacunaId",
                principalTable: "StavkeRacuna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usluga_ZaglavljeRacuna_ZaglavljeRacunaId",
                table: "Usluga",
                column: "ZaglavljeRacunaId",
                principalTable: "ZaglavljeRacuna",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usluga_Partner_PartnerId",
                table: "Usluga");

            migrationBuilder.DropForeignKey(
                name: "FK_Usluga_StavkeRacuna_StavkeRacunaId",
                table: "Usluga");

            migrationBuilder.DropForeignKey(
                name: "FK_Usluga_ZaglavljeRacuna_ZaglavljeRacunaId",
                table: "Usluga");

            migrationBuilder.DropForeignKey(
                name: "FK_ZaglavljeRacuna_Partner_PartnerId",
                table: "ZaglavljeRacuna");

            migrationBuilder.DropIndex(
                name: "IX_ZaglavljeRacuna_PartnerId",
                table: "ZaglavljeRacuna");

            migrationBuilder.DropIndex(
                name: "IX_Usluga_PartnerId",
                table: "Usluga");

            migrationBuilder.DropIndex(
                name: "IX_Usluga_StavkeRacunaId",
                table: "Usluga");

            migrationBuilder.DropIndex(
                name: "IX_Usluga_ZaglavljeRacunaId",
                table: "Usluga");

            migrationBuilder.DropIndex(
                name: "IX_StavkeRacuna_ZaglavljeRacunaId",
                table: "StavkeRacuna");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Partner",
                table: "Partner");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Usluga");

            migrationBuilder.DropColumn(
                name: "StavkeRacunaId",
                table: "Usluga");

            migrationBuilder.DropColumn(
                name: "ZaglavljeRacunaId",
                table: "Usluga");

            migrationBuilder.RenameTable(
                name: "Partner",
                newName: "Partneri");

            migrationBuilder.RenameColumn(
                name: "PartnerId",
                table: "ZaglavljeRacuna",
                newName: "KupacId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Partneri",
                table: "Partneri",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeRacuna_ZaglavljeRacunaId",
                table: "StavkeRacuna",
                column: "ZaglavljeRacunaId",
                unique: true);
        }
    }
}
