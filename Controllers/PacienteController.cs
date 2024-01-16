using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.Entidades;
using ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Controllers
{
    public class PacienteController : Controller
    {
        public readonly HospitalContext _context;

        public PacienteController(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoPaciente()
        {
            return View(await _context.Pacientes.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Paciente creado exitosamente";
                return RedirectToAction("ListadoPaciente");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Ha ocurrido un error");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }

            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return View(paciente);
        }
        public async Task<IActionResult> Editar(int IdPaciente, Paciente paciente)
        {
            if (IdPaciente != paciente.IdPaciente)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync();
                    TempData["AlerMessage"] = "Paciente Actualizado" + "Exitosamente!";
                    return RedirectToAction("ListadoPaciente");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error" + "Al actualizar");

                }
            }

            return View(paciente);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Pacientes == null)
            {
                return NotFound();
            }
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(a => a.IdPaciente == id);
            if (paciente == null)
            {
                return NotFound();
            }
            try
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Paciente Eliminado Exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }
            return RedirectToAction(nameof(ListadoPaciente));
        }
    }
}
