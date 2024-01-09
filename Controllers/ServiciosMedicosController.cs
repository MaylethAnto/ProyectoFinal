using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class ServiciosMedicosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
