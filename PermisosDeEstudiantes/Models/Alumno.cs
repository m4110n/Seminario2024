using System;
using System.ComponentModel.DataAnnotations;

namespace PermisosDeEstudiantes.Models
{
    public class Alumno
    {
        [Key]
        public int CodigoEstudiante { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        [Display(Name = "Grado Cursando")]
        [StringLength(50)]
        public string GradoCursando { get; set; }

        [Required]
        [Display(Name = "Ciclo Escolar")]
        [StringLength(10)]
        public string CicloEscolar { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Correo { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Alumno Activo")]
        public bool AlumnoActivo { get; set; } // true para activo, false para inactivo
    }
}
