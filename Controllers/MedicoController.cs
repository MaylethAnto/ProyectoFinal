using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class MedicoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
