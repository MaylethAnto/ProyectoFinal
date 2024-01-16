using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.Entidades;
using ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Controllers
{
    public class EspecialidadController : Controller
    {
        public readonly HospitalContext _context;

        public EspecialidadController(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoEspecialidadM()
        {
            return View(await _context.especialidadMedicos.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(EspecialidadMedico especialidadMedico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidadMedico);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Especialidad Medica creada exitosamente";
                return RedirectToAction("ListadoEspecialidadM");
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
            if (id == null || _context.especialidadMedicos == null)
            {
                return NotFound();
            }

            var especialidadMedico = await _context.especialidadMedicos.FindAsync(id);

            if (especialidadMedico == null)
            {
                return NotFound();
            }

            return View(especialidadMedico);
        }
        public async Task<IActionResult> Editar(int IdEspecialidad, EspecialidadMedico especialidadMedico)
        {
            if (IdEspecialidad != especialidadMedico.IdEspecialidad)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidadMedico);
                    await _context.SaveChangesAsync();
                    TempData["AlerMessage"] = "Especialidad Medica Actualizada" + "Exitosamente!";
                    return RedirectToAction("ListadoEspecialidadM");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error" + "Al actualizar");

                }
            }

            return View(especialidadMedico);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.especialidadMedicos == null)
            {
                return NotFound();
            }
            var especialidadMedico = await _context.especialidadMedicos.FirstOrDefaultAsync(a => a.IdEspecialidad == id);
            if (especialidadMedico == null)
            {
                return NotFound();
            }
            try
            {
                _context.especialidadMedicos.Remove(especialidadMedico);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Especialidad Medica Eliminada Exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }
            return RedirectToAction(nameof(ListadoEspecialidadM));
        }
    }
}
