using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermisosDeEstudiantes.Migrations
{
    /// <inheritdoc />
    public partial class smike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermisoEstudiante",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CodigoEstudiante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisoEstudiante", x => x.IdPermiso);
                    table.ForeignKey(
                        name: "FK_PermisoEstudiante_Alumno_CodigoEstudiante",
                        column: x => x.CodigoEstudiante,
                        principalTable: "Alumno",
                        principalColumn: "CodigoEstudiante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PermisoEstudiante_CodigoEstudiante",
                table: "PermisoEstudiante",
                column: "CodigoEstudiante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermisoEstudiante");
        }
    }
}
