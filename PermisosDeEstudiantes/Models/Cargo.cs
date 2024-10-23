using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermisosDeEstudiantes.Models
{
    public class Cargo
    {
        [Key]
        public int IdCargo { get; set; }
        [Display(Name = "Nombre de Cargo")]
        public string? Nombre { get; set; }

       

    }
}
