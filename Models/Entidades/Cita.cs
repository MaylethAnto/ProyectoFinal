using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public ConsultaMedica consultaMedica { get; set;}
        public Consultorio consultorio { get; set; }

        public RecetaMedica recetaMedica { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un Paciente.")]
        public int PacienteId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar una Consulta Medica.")]
        public int ConsultaMedicaId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un Consultorio.")]
        public int ConsultorioaId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar una Receta Medica.")]
        public int RecetaMedicaId { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> Pacientes { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> ConsultasMedicas { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> Consultorios { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> RecetasMedicas { get; set; }

    }
}
