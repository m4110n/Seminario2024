using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermisosDeEstudiantes.Migrations
{
    /// <inheritdoc />
    public partial class addClasePermiso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEstudiante = table.Column<int>(type: "int", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.IdPermiso);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permiso");
        }
    }
}
