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

        public string correo { get; set; }

        public string password { get; set; }

        //llave foranea
        public Cita Cita { get; set; }
        public EspecialidadMedico EspecialidadMedico { get; set; }
    }
}
