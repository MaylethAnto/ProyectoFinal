using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.Entidades;
using ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Controllers
{
    public class RecetaMedicaController : Controller
    {
        public readonly HospitalContext _context;

        public RecetaMedicaController(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoRecetaMedica()
        {
            return View(await _context.RecetaMedicas.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(RecetaMedica recetaMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recetaMedica);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Receta Medica creado exitosamente";
                return RedirectToAction("ListadoRecetaMedica");
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
            if (id == null || _context.RecetaMedicas == null)
            {
                return NotFound();
            }

            var recetaMedica = await _context.RecetaMedicas.FindAsync(id);

            if (recetaMedica == null)
            {
                return NotFound();
            }

            return View(recetaMedica);
        }
        public async Task<IActionResult> Editar(int IdReceta, RecetaMedica recetaMedica)
        {
            if (IdReceta != recetaMedica.IdReceta)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recetaMedica);
                    await _context.SaveChangesAsync();
                    TempData["AlerMessage"] = "Receta Medica Actualizada" + "Exitosamente!";
                    return RedirectToAction("ListadoRecetaMedica");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error" + "Al actualizar");

                }
            }

            return View(recetaMedica);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.RecetaMedicas == null)
            {
                return NotFound();
            }
            var recetaMedica = await _context.RecetaMedicas.FirstOrDefaultAsync(a => a.IdReceta == id);
            if (recetaMedica == null)
            {
                return NotFound();
            }
            try
            {
                _context.RecetaMedicas.Remove(recetaMedica);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Receta Medica Eliminado Exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }
            return RedirectToAction(nameof(ListadoRecetaMedica));
        }
    }
}
