using System.ComponentModel.DataAnnotations;

namespace PermisosDeEstudiantes.Models
{
    public class Estado
    {

        [Key]

        public int IdEstado { get; set; }

        [Display(Name= "Nombre del estado")]
        public string? Nombre { get; set; }
    }
}
