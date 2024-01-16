using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entidades
{
    public class ConsultaMedica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string diagnostico { get; set; }
        public DateTime fecha_examen { get; set; }
        public string resultado { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [Column(TypeName = "decimal (18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal precio { get; set; }

        //llaves foraneas

        public ServiciosMedicos serviciosmedicos { get; set; }
     

    }
}
