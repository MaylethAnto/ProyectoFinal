using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entidades
{
    public class Medico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMedico { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string nombre_medico { get; set; }
        public string especialidad_medico { get; set; }

        public bool estado_medico { get; set; }


    }
}
