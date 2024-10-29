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

        // Acci�n para la vista de Estudiante sin requerir autenticaci�n
        [AllowAnonymous]
        public IActionResult VistaEstudiante()
        {
            return View();
        }

        // Acci�n para la vista de Catedr�tico que requiere autenticaci�n
        [Authorize]
        public IActionResult VistaCatedratico()
        {
            return View();
        }


        // Acci�n para la vista de Estudiante sin requerir autenticaci�n
        [AllowAnonymous]
        public IActionResult Consultar()
        {
            return View();
        }
    }
}
