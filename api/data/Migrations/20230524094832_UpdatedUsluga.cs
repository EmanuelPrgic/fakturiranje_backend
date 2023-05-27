using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUsluga : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usluga_Partner_PartnerId",
                table: "Usluga");

            migrationBuilder.DropForeignKey(
                name: "FK_Usluga_ZaglavljeRacuna_ZaglavljeRacunaId",
                table: "Usluga");

            migrationBuilder.DropIndex(
                name: "IX_Usluga_PartnerId",
                table: "Usluga");

            migrationBuilder.DropIndex(
                name: "IX_Usluga_ZaglavljeRacunaId",
                table: "Usluga");

            migrationBuilder.DropColumn(
                name: "PartnerId",
                table: "Usluga");

            migrationBuilder.DropColumn(
                name: "ZaglavljeRacunaId",
                table: "Usluga");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PartnerId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Usluga_PartnerId",
                table: "Usluga",
                column: "PartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Usluga_ZaglavljeRacunaId",
                table: "Usluga",
                column: "ZaglavljeRacunaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usluga_Partner_PartnerId",
                table: "Usluga",
                column: "PartnerId",
                principalTable: "Partner",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usluga_ZaglavljeRacuna_ZaglavljeRacunaId",
                table: "Usluga",
                column: "ZaglavljeRacunaId",
                principalTable: "ZaglavljeRacuna",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
