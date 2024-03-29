﻿using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models.Entidades;
using ProyectoFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Controllers
{
    public class ConsultorioController : Controller
    {
        public readonly HospitalContext _context;

        public ConsultorioController(HospitalContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ListadoConsultorio()
        {
            return View(await _context.Consultorios.ToListAsync());
        }

        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultorio);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Consultorio creado exitosamente";
                return RedirectToAction("ListadoConsultorio");
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
            if (id == null || _context.Consultorios == null)
            {
                return NotFound();
            }

            var consultorio = await _context.Consultorios.FindAsync(id);

            if (consultorio == null)
            {
                return NotFound();
            }

            return View(consultorio);
        }
        public async Task<IActionResult> Editar(int IdConsultorio, Consultorio consultorio)
        {
            if (IdConsultorio != consultorio.IdConsultorio)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultorio);
                    await _context.SaveChangesAsync();
                    TempData["AlerMessage"] = "Consultorio Actualizado" + "Exitosamente!";
                    return RedirectToAction("ListadoConsultorio");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(ex.Message, "Ocurrio un error" + "Al actualizar");

                }
            }

            return View(consultorio);
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null || _context.Consultorios == null)
            {
                return NotFound();
            }
            var consultorio = await _context.Consultorios.FirstOrDefaultAsync(a => a.IdConsultorio == id);
            if (consultorio == null)
            {
                return NotFound();
            }
            try
            {
                _context.Consultorios.Remove(consultorio);
                await _context.SaveChangesAsync();
                TempData["AlertMessage"] = "Consultorio Eliminado Exitosamente";
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "Ocurrio un error, no se pudo eliminar el registro");
            }
            return RedirectToAction(nameof(ListadoConsultorio));
        }
    }
}
