using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermisosDeEstudiantes.Models
{
    public class PermisoEstudiante
    {
        [Key]
        public int IdPermiso { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Inicio")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Final")]
        public DateTime FechaFin { get; set; }

        [Display(Name = "Motivo")]
        [StringLength(250)]
        public string? Motivo { get; set; }

        [Required]
        [ForeignKey("Alumno")]
        [Display(Name = "Código del Estudiante")]
        public int CodigoEstudiante { get; set; }

        // Relación con el modelo Alumno
        public Alumno? Alumno { get; set; }

        [Display(Name = "Estado del Permiso")]
        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "--"; // Estado por defecto: "--"
    }
}

