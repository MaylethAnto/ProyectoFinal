using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using ProyectoFinal.Models.Entidades;

namespace ProyectoFinal.Services
{
    public class ServicioMedico : IServicioMedico
    {
        private readonly HospitalContext _context; //informacion de la libreria context de entidades

        public ServicioMedico(HospitalContext context)
        {
            _context = context;
        }


        public async Task<Medico> GetMedico(string correo, string password)
        {

            Medico medico = await _context.Medicos.Where(u => u.correo == correo && u.password == password).FirstOrDefaultAsync();

            return medico;

        }

        public async Task<Medico> GetMedico(string nombre_medico)
        {
            return await _context.Medicos.FirstOrDefaultAsync(m => m.nombre_medico == nombre_medico);

        }

        public async Task<Medico> SaveMedico(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }


    }
}
