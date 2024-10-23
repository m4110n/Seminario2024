using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PermisosDeEstudiantes.Models;

namespace PermisosDeEstudiantes.Models
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // aqui agregan las tablas y modelos
        public DbSet<Persona> Persona { get; set; }
        public DbSet<Cargo> cargo { get; set; }
        public DbSet<PermisosDeEstudiantes.Models.Estado> Estado { get; set; } = default!;
        public DbSet<PermisosDeEstudiantes.Models.Permiso> Permiso { get; set; } = default!;
        public DbSet<PermisosDeEstudiantes.Models.Estudiante> Estudiante { get; set; } = default!;
        public DbSet<PermisosDeEstudiantes.Models.Categoria> Categoria { get; set; } = default!;
        // finaliza
    }
}
