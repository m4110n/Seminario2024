using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermisosDeEstudiantes.Migrations
{
    /// <inheritdoc />
    public partial class smike2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "PermisoEstudiante",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "PermisoEstudiante");
        }
    }
}
