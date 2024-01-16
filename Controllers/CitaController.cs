using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;
using ProyectoFinal.Models.Entidades;

namespace ProyectoFinal.Controllers
{
    public class CitaController : Controller
    {
        public readonly HospitalContext _context;

        public CitaController(HospitalContext context)
        { 
            _context = context;
        }
        public async Task<IActionResult> ListadoCitas()
        { 
            return View(await _context.Citas.ToListAsync());
        }

        public IActionResult Crear() 
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Cita cita)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cita);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Cita creada exitosamente";
                return RedirectToAction("ListadoCitas");
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
            if (id == null || _context.Citas == null)
            { 
                return NotFound();
            }

            var citas = await _context.Citas.FindAsync(id);

            if (citas == null)
            {
                return NotFound();
            }

            return View(citas);
        }
        public async Task<IActionResult> Editar(int IdCita, Cita cita)
        { 
            if(IdCita != cita.IdCita)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cita);
                    await _context.SaveChangesAsync();
                    TempData["AlerMessage"] = "Cita Actualizada" + "Exitosamente!";
                    return RedirectToAction("ListadoCitas");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error" + "Al actualizar");

                }
            }

            return View(cita);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Citas == null) 
            {
                return NotFound();
            }
            var citas = await _context.Citas.FirstOrDefaultAsync(a => a.IdCita == id);
            if (citas == null)
            {
                return NotFound();
            }
            try 
            {
                _context.Citas.Remove(citas);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Cita Eliminada Exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }
            return RedirectToAction(nameof(ListadoCitas));
        }

    }
}
