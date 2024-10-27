using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace PermisosDeEstudiantes.Models

{
    public class Permiso
    {

        [Key]

        public int IdPermiso  { get; set; }

        [Display(Name = "ID Estudiante")]
        public int IdEstudiante { get; set; }


        [Display(Name = "Motivo de Permiso" )]
        [Required(ErrorMessage ="El motivo es obligatorio")]
           public string? Motivo { get; set; }

        [Display(Name =" ID Categoria")]
        public int IdCategoria { get; set; }

        [Display(Name="Fecha")]
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }

        [Display(Name = "ID Estado")]
        public int IdEstado { get; set; }



    }
}
