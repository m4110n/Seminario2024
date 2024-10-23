using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermisosDeEstudiantes.Migrations
{
    /// <inheritdoc />
    public partial class Migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cargo",
                columns: table => new
                {
                    IdCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargo", x => x.IdCargo);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    IdPersona = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCargo = table.Column<int>(type: "int", nullable: false),
                    CargoIdCargo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.IdPersona);
                    table.ForeignKey(
                        name: "FK_Persona_cargo_CargoIdCargo",
                        column: x => x.CargoIdCargo,
                        principalTable: "cargo",
                        principalColumn: "IdCargo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_CargoIdCargo",
                table: "Persona",
                column: "CargoIdCargo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "cargo");
        }
    }
}
