using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PermisosDeEstudiantes.Models
{
    public class Persona
    {
        [Key]
        public int IdPersona { get; set; }

        [Display(Name = "Nombre completo")]
        public string? Nombre { get; set; }

        [Display(Name = "Estatura de Persona")]
        [Precision(18,2)]
        public decimal Estatura { get; }
        [DisplayName("Cargo")]
        [ForeignKey("idCargo")]
        public int idCargo { get; set; }
        public virtual Cargo? Cargo { get; set; }
    }
}
