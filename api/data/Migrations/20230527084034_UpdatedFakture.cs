using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedFakture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkeRacuna_ZaglavljeRacuna_ZaglavljeRacunaId",
                table: "StavkeRacuna");

            migrationBuilder.DropIndex(
                name: "IX_ZaglavljeRacuna_PartnerId",
                table: "ZaglavljeRacuna");

            migrationBuilder.AlterColumn<int>(
                name: "ZaglavljeRacunaId",
                table: "StavkeRacuna",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "BrojRacuna",
                table: "StavkeRacuna",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ZaglavljeRacuna_PartnerId",
                table: "ZaglavljeRacuna",
                column: "PartnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_StavkeRacuna_ZaglavljeRacuna_ZaglavljeRacunaId",
                table: "StavkeRacuna",
                column: "ZaglavljeRacunaId",
                principalTable: "ZaglavljeRacuna",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StavkeRacuna_ZaglavljeRacuna_ZaglavljeRacunaId",
                table: "StavkeRacuna");

            migrationBuilder.DropIndex(
                name: "IX_ZaglavljeRacuna_PartnerId",
                table: "ZaglavljeRacuna");

            migrationBuilder.DropColumn(
                name: "BrojRacuna",
                table: "StavkeRacuna");

            migrationBuilder.AlterColumn<int>(
                name: "ZaglavljeRacunaId",
                table: "StavkeRacuna",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ZaglavljeRacuna_PartnerId",
                table: "ZaglavljeRacuna",
                column: "PartnerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StavkeRacuna_ZaglavljeRacuna_ZaglavljeRacunaId",
                table: "StavkeRacuna",
                column: "ZaglavljeRacunaId",
                principalTable: "ZaglavljeRacuna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
