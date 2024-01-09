using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entidades
{
    public class Consultorio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConsultorio { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int numero_consultorio { get; set; }
        public string direccion_consultorio { get; set; }
        public string telefono_consultorio { get; set; }

    }
}
