using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PermisosDeEstudiantes.Models;

namespace PermisosDeEstudiantes.Controllers
{
    public class PermisoController : Controller
    {
        private readonly AppDbContext _context;

        public PermisoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Permiso
        public async Task<IActionResult> Index()
        {
            return View(await _context.Permiso.ToListAsync());
        }

        // GET: Permiso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permiso = await _context.Permiso
                .FirstOrDefaultAsync(m => m.IdPermiso == id);
            if (permiso == null)
            {
                return NotFound();
            }

            return View(permiso);
        }

        // GET: Permiso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Permiso/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPermiso,IdEstudiante,Motivo,IdCategoria,Fecha,IdEstado")] Permiso permiso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(permiso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(permiso);
        }

        // GET: Permiso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permiso = await _context.Permiso.FindAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }
            return View(permiso);
        }

        // POST: Permiso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPermiso,IdEstudiante,Motivo,IdCategoria,Fecha,IdEstado")] Permiso permiso)
        {
            if (id != permiso.IdPermiso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(permiso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PermisoExists(permiso.IdPermiso))
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
            return View(permiso);
        }

        // GET: Permiso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var permiso = await _context.Permiso
                .FirstOrDefaultAsync(m => m.IdPermiso == id);
            if (permiso == null)
            {
                return NotFound();
            }

            return View(permiso);
        }

        // POST: Permiso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var permiso = await _context.Permiso.FindAsync(id);
            if (permiso != null)
            {
                _context.Permiso.Remove(permiso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PermisoExists(int id)
        {
            return _context.Permiso.Any(e => e.IdPermiso == id);
        }

        // GET: Permiso/Consultar
        public IActionResult Consultar()
        {
            return View();
        }

        // POST: Permiso/Consultar
        [HttpPost]
        public async Task<IActionResult> Consultar(int? searchId)
        {
            if (searchId == null)
            {
                ViewBag.Message = "Por favor, ingrese un ID de Permiso.";
                return View();
            }

            var permiso = await _context.Permiso
                .FirstOrDefaultAsync(m => m.IdPermiso == searchId);

            if (permiso == null)
            {
                ViewBag.Message = "No se encontró ningún permiso con el ID especificado.";
                return View();
            }

            return View(permiso);
        }

    }
}
