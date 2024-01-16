using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.Entidades;
using ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Controllers
{
    public class HorarioController : Controller
    {
        public readonly HospitalContext _context;

        public HorarioController(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoHorario()
        {
            return View(await _context.Horarios.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Horario horario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(horario);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Horario creado exitosamente";
                return RedirectToAction("ListadoHorario");
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
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }

            var horario = await _context.Horarios.FindAsync(id);

            if (horario == null)
            {
                return NotFound();
            }

            return View(horario);
        }
        public async Task<IActionResult> Editar(int IdHorario, Horario horario)
        {
            if (IdHorario != horario.IdHorario)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(horario);
                    await _context.SaveChangesAsync();
                    TempData["AlerMessage"] = "Horario Actualizado" + "Exitosamente!";
                    return RedirectToAction("ListadoHorario");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error" + "Al actualizar");

                }
            }

            return View(horario);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Horarios == null)
            {
                return NotFound();
            }
            var horario = await _context.Horarios.FirstOrDefaultAsync(a => a.IdHorario == id);
            if (horario == null)
            {
                return NotFound();
            }
            try
            {
                _context.Horarios.Remove(horario);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Horario Eliminado Exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }
            return RedirectToAction(nameof(ListadoHorario));
        }
    }
}
