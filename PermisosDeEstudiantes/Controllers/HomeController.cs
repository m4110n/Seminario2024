using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermisosDeEstudiantes.Models;
using System.Diagnostics;

namespace PermisosDeEstudiantes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Acción para la vista de Estudiante sin requerir autenticación
        [AllowAnonymous]
        public IActionResult VistaEstudiante()
        {
            return View();
        }

        // Acción para la vista de Catedrático que requiere autenticación
        [Authorize]
        public IActionResult VistaCatedratico()
        {
            return View();
        }


        // Acción para la vista de Estudiante sin requerir autenticación
        [AllowAnonymous]
        public IActionResult Consultar()
        {
            return View();
        }
    }
}
