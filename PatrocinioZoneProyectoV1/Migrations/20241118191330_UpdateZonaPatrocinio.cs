using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatrocinioZoneProyectoV1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateZonaPatrocinio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tamanio",
                table: "ZonaPatrocinios",
                newName: "Tamanio");

            migrationBuilder.RenameColumn(
                name: "estadoReservado",
                table: "ZonaPatrocinios",
                newName: "EstadoReservado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Tamanio",
                table: "ZonaPatrocinios",
                newName: "tamanio");

            migrationBuilder.RenameColumn(
                name: "EstadoReservado",
                table: "ZonaPatrocinios",
                newName: "estadoReservado");
        }
    }
}
