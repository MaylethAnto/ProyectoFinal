using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entidades
{
    public class ServiciosMedicos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdServicio { get; set; }

        [Required(ErrorMessage = "El campo { 0 } es obligatorio")]
        public string descripcion_servicio { get; set; }
        public string tipo_servicio { get; set; }

        public bool estado_servicio { get; set; }
    }
}
