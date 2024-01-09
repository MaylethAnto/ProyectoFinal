using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entidades
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCita { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int estado_cita { get; set; }

        //llaves foraneas
        public Paciente paciente { get; set; }

        public Horario horario { get; set; }
        public ConsultaMedica consultaMedica { get; set;}

       
    }
}
