using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entidades
{
    public class EspecialidadMedico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEspecialidad { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string NombreEspecialidad { get; set; }

        [Display(Name = "Disponibilidad")]
        public bool Disponible { get; set; }

    }
}
