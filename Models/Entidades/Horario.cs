using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entidades
{
    public class Horario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdHorario { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime fecha_horario { get; set; }
        public int estado_horario { get; set; }

        //llave foranea
        public Cita citas { get; set; }
    }
}
