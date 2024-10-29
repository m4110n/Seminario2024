using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PermisosDeEstudiantes.Models;

namespace PermisosDeEstudiantes.Controllers
{
    [Authorize]
    public class PermisoEstudianteController : Controller
    {
        private readonly AppDbContext _context;

        public PermisoEstudianteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PermisoEstudiante
        public async Task<IActionResult> Index()
        {
            var appDbContext = await _context.PermisoEstudiante
                .Include(p => p.Alumno)
                .Where(p => p.Status == "--") // Filtrar por estado
                .ToListAsync();

            return View(appDbContext);
        }


        // GET: PermisoEstudiante/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoEstudiante = await _context.PermisoEstudiante
                .Include(p => p.Alumno)
                .FirstOrDefaultAsync(m => m.IdPermiso == id);
            if (permisoEstudiante == null)
            {
                return NotFound();
            }

            return View(permisoEstudiante);
        }

        // GET: PermisoEstudiante/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            ViewData["CodigoEstudiante"] = new SelectList(_context.Alumno, "CodigoEstudiante", "NombreCompleto");
            return View();
        }

        // POST: PermisoEstudiante/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPermiso,FechaInicio,FechaFin,Motivo,CodigoEstudiante")] PermisoEstudiante permisoEstudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permisoEstudiante);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Permiso solicitado correctamente."; // Mensaje de éxito
                return RedirectToAction("VistaEstudiante", "Home"); // Redirige a VistaEstudiante
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Alumno, "CodigoEstudiante", "NombreCompleto", permisoEstudiante.CodigoEstudiante);
            return View(permisoEstudiante);
        }


        // GET: PermisoEstudiante/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoEstudiante = await _context.PermisoEstudiante.FindAsync(id);
            if (permisoEstudiante == null)
            {
                return NotFound();
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Alumno, "CodigoEstudiante", "NombreCompleto", permisoEstudiante.CodigoEstudiante);
            return View(permisoEstudiante);
        }


        // POST: PermisoEstudiante/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPermiso,FechaInicio,FechaFin,Motivo,CodigoEstudiante, Status")] PermisoEstudiante permisoEstudiante)
        {
            if (id != permisoEstudiante.IdPermiso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permisoEstudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisoEstudianteExists(permisoEstudiante.IdPermiso))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoEstudiante"] = new SelectList(_context.Alumno, "CodigoEstudiante", "NombreCompleto", permisoEstudiante.CodigoEstudiante);
            return View(permisoEstudiante);
        }


        // GET: PermisoEstudiante/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permisoEstudiante = await _context.PermisoEstudiante
                .Include(p => p.Alumno)
                .FirstOrDefaultAsync(m => m.IdPermiso == id);
            if (permisoEstudiante == null)
            {
                return NotFound();
            }

            return View(permisoEstudiante);
        }

        // POST: PermisoEstudiante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permisoEstudiante = await _context.PermisoEstudiante.FindAsync(id);
            if (permisoEstudiante != null)
            {
                _context.PermisoEstudiante.Remove(permisoEstudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisoEstudianteExists(int id)
        {
            return _context.PermisoEstudiante.Any(e => e.IdPermiso == id);
        }
        //Historico
        public async Task<IActionResult> Historial()
        {
            var historicoPermisos = await _context.PermisoEstudiante.ToListAsync(); 
            return View(historicoPermisos);
        }

        // GET: Consultar
        [AllowAnonymous]
        public IActionResult Consultar()
        {
            return View();
        }

        // POST: Consultar
        [HttpPost]
        public IActionResult Consultar(ConsultarPermisoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var permisos = _context.PermisoEstudiante
                .Where(p => p.CodigoEstudiante == model.CodigoEstudiante)
                .ToList();

            return View("ResultadosConsulta", permisos);
        }


    }
}