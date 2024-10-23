using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace PermisosDeEstudiantes.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }

        [Display(Name = "Nombre de la Categoría")]
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        public string? Nombre { get; set; }


    }
}
