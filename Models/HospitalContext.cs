using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models.Entidades;

namespace ProyectoFinal.Models
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }
        public DbSet<Cita> Citas { get; set; }
        public DbSet<ConsultaMedica> ConsultaMedicas { get; set; }
        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<RecetaMedica> RecetaMedicas { get; set; }

        public DbSet<EspecialidadMedico> especialidadMedicos { get; set; }

        public DbSet<ServiciosMedicos> ServiciosMedicos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)  //Este metodo q va ayudar a conectar con la BDD
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
