using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class ConsultorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
