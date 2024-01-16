using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.Entidades;
using ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Controllers
{
    public class ConsultaMedicaController : Controller
    {
        public readonly HospitalContext _context;

        public ConsultaMedicaController(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoConsultaMedica()
        {
            return View(await _context.ConsultaMedicas.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(ConsultaMedica consultaMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultaMedica);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Consulta medica creada exitosamente";
                return RedirectToAction("ListadoConsultaMedica");
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
            if (id == null || _context.ConsultaMedicas == null)
            {
                return NotFound();
            }

            var consultamedica = await _context.ConsultaMedicas.FindAsync(id);

            if (consultamedica == null)
            {
                return NotFound();
            }

            return View(consultamedica);
        }
        public async Task<IActionResult> Editar(int IdConsulta, ConsultaMedica consultaMedica)
        {
            if (IdConsulta != consultaMedica.IdConsulta)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultaMedica);
                    await _context.SaveChangesAsync();
                    TempData["AlerMessage"] = "Consulta Medica Actualizada" + "Exitosamente!";
                    return RedirectToAction("ListadoConsultaMedica");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error" + "Al actualizar");

                }
            }

            return View(consultaMedica);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.ConsultaMedicas == null)
            {
                return NotFound();
            }
            var consultamedica= await _context.ConsultaMedicas.FirstOrDefaultAsync(a => a.IdConsulta == id);
            if (consultamedica == null)
            {
                return NotFound();
            }
            try
            {
                _context.ConsultaMedicas.Remove(consultamedica);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Consulta Medica Eliminada Exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }
            return RedirectToAction(nameof(ListadoConsultaMedica));
        }
    }
}
