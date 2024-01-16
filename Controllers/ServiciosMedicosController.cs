using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.Entidades;
using ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Controllers
{
    public class ServiciosMedicosController : Controller
    {
        public readonly HospitalContext _context;

        public ServiciosMedicosController(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoServiciosM()
        {
            return View(await _context.ServiciosMedicos.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(ServiciosMedicos serviciosMedicos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serviciosMedicos);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "El servicio se ha creado exitosamente";
                return RedirectToAction("ListadoServiciosM");
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
            if (id == null || _context.ServiciosMedicos == null)
            {
                return NotFound();
            }

            var serviciosMedicos = await _context.ServiciosMedicos.FindAsync(id);

            if (serviciosMedicos == null)
            {
                return NotFound();
            }

            return View(serviciosMedicos);
        }
        public async Task<IActionResult> Editar(int IdServicio, ServiciosMedicos serviciosMedicos)
        {
            if (IdServicio != serviciosMedicos.IdServicio)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviciosMedicos);
                    await _context.SaveChangesAsync();
                    TempData["AlerMessage"] = "Servios Actualizados" + "Exitosamente!";
                    return RedirectToAction("ListadoServiciosM");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error" + "Al actualizar");

                }
            }

            return View(serviciosMedicos);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.ServiciosMedicos == null)
            {
                return NotFound();
            }
            var serviciosMedicos = await _context.ServiciosMedicos.FirstOrDefaultAsync(a => a.IdServicio == id);
            if (serviciosMedicos == null)
            {
                return NotFound();
            }
            try
            {
                _context.ServiciosMedicos.Remove(serviciosMedicos);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Servicio Medico Eliminado Exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }
            return RedirectToAction(nameof(ListadoServiciosM));
        }
    }
}
