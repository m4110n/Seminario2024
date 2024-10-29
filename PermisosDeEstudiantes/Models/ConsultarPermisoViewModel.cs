using System.ComponentModel.DataAnnotations;

namespace PermisosDeEstudiantes.Models
{
    public class ConsultarPermisoViewModel
    {
        [Required]
        [Display(Name = "Código del Estudiante")]
        public int CodigoEstudiante { get; set; }
    }
}
