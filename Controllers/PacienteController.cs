using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class PacienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
