using ProyectoFinal.Models.Entidades;

namespace ProyectoFinal.Services
{
    public interface IServicioMedico
    {
        Task<Medico> GetMedico(String correo, string contraseña);

        Task<Medico> SaveMedico(Medico medico);

        Task<Medico> GetMedico(string nombre_medico);
    }
}
