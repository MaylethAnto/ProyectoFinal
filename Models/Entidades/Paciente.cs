using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entidades
{
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string nombre_paciente { get; set; }
        public string apellido_paciente { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public string direccion_paciente { get; set; }
        public string correo_paciente { get; set; }
        public string telefono_paciente { get; set; }
        public int estado_paciente { get; set; }

    }
}
