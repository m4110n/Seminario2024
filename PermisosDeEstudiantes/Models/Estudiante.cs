using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PermisosDeEstudiantes.Models
{
    public class Estudiante
    {
        [Key]

        public int IdEstudiante { get; set; }

        [Display(Name ="Nombre Completo")]
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio.")]
        public string? Apellido { get; set; }

        [Display(Name ="Direccion")]
        public string? Direccion { get; set; }

        [Display(Name = "Telefono")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public int ? Telefono { get; set; }

        [Display(Name = "Gmail")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string? Gmail { get; set; }


    }
}
