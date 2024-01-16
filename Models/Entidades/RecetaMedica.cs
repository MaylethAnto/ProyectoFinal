using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entidades
{
    public class RecetaMedica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdReceta { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string dosis_medica { get; set; }
        public string observaciones { get; set; } 



  
    }
}
