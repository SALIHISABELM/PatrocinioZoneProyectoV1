using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatrocinioZoneProyectoV1.Migrations
{
    /// <inheritdoc />
    public partial class FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ofertas",
                table: "ofertas");

            migrationBuilder.RenameTable(
                name: "ofertas",
                newName: "Ofertas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ofertas",
                table: "Ofertas",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_ClubID",
                table: "Ofertas",
                column: "ClubID");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_PatrocinadorID",
                table: "Ofertas",
                column: "PatrocinadorID");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_ZonaDePatrocinioID",
                table: "Ofertas",
                column: "ZonaDePatrocinioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Ofertas_Clubes_ClubID",
                table: "Ofertas",
                column: "ClubID",
                principalTable: "Clubes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ofertas_Patrocinadores_PatrocinadorID",
                table: "Ofertas",
                column: "PatrocinadorID",
                principalTable: "Patrocinadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ofertas_ZonaPatrocinios_ZonaDePatrocinioID",
                table: "Ofertas",
                column: "ZonaDePatrocinioID",
                principalTable: "ZonaPatrocinios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_Clubes_ClubID",
                table: "Ofertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_Patrocinadores_PatrocinadorID",
                table: "Ofertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_ZonaPatrocinios_ZonaDePatrocinioID",
                table: "Ofertas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ofertas",
                table: "Ofertas");

            migrationBuilder.DropIndex(
                name: "IX_Ofertas_ClubID",
                table: "Ofertas");

            migrationBuilder.DropIndex(
                name: "IX_Ofertas_PatrocinadorID",
                table: "Ofertas");

            migrationBuilder.DropIndex(
                name: "IX_Ofertas_ZonaDePatrocinioID",
                table: "Ofertas");

            migrationBuilder.RenameTable(
                name: "Ofertas",
                newName: "ofertas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ofertas",
                table: "ofertas",
                column: "OfertaId");
        }
    }
}
