using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_PrograAvanzada.Models;

namespace Proyecto_PrograAvanzada.Controllers
{
    public class AsignacionController : Controller
    {
        private readonly ServiciosSoporteContext _context;

        public AsignacionController(ServiciosSoporteContext context)
        {
            _context = context;
        }

        // GET: Asignacions
        public async Task<IActionResult> Index()
        {
            var serviciosSoporteContext = _context.Asignaciones.Include(a => a.IdSolicitudNavigation).Include(a => a.IdTecnicoNavigation);
            return View(await serviciosSoporteContext.ToListAsync());
        }

        // GET: Asignacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.IdSolicitudNavigation)
                .Include(a => a.IdTecnicoNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        //// GET: Asignacions/Create
        public IActionResult Create()
        {
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitudes, "IdSolicitud", "Descripcion");
            ViewData["IdTecnico"] = new SelectList(
                _context.Tecnicos.Include(t => t.IdUsuarioNavigation),
                "IdTecnico",
                "IdUsuarioNavigation.Nombre"
            );
            return View();
        }

        //// POST: Asignacions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignacion,IdSolicitud,IdTecnico,FechaAsignacion,FechaInicio,FechaCierre")] Asignacion asignacion)
        {
            if (ModelState.IsValid)
            {
                asignacion.FechaAsignacion = DateTime.Now; // Agregar fecha de asignación automática
                _context.Add(asignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitudes, "IdSolicitud", "Descripcion", asignacion.IdSolicitud);
            ViewData["IdTecnico"] = new SelectList(
                _context.Tecnicos.Include(t => t.IdUsuarioNavigation),
                "IdTecnico",
                "IdUsuarioNavigation.Nombre",
                asignacion.IdTecnico
            );
            return View(asignacion);
        }

        //// GET: Asignacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion == null)
            {
                return NotFound();
            }
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitudes, "IdSolicitud", "Descripcion", asignacion.IdSolicitud);
            ViewData["IdTecnico"] = new SelectList(
                _context.Tecnicos.Include(t => t.IdUsuarioNavigation),
                "IdTecnico",
                "IdUsuarioNavigation.Nombre",
                asignacion.IdTecnico
            );
            return View(asignacion);
        }


        // POST: Asignacions/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacion,IdSolicitud,IdTecnico,FechaAsignacion,FechaInicio,FechaCierre")] Asignacion asignacion)
        {
            if (id != asignacion.IdAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionExists(asignacion.IdAsignacion))
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
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitudes, "IdSolicitud", "Descripcion", asignacion.IdSolicitud);
            ViewData["IdTecnico"] = new SelectList(
                _context.Tecnicos.Include(t => t.IdUsuarioNavigation),
                "IdTecnico",
                "IdUsuarioNavigation.Nombre",
                asignacion.IdTecnico
            );
            return View(asignacion);
        }


        // GET: Asignacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacion = await _context.Asignaciones
                .Include(a => a.IdSolicitudNavigation)
                .Include(a => a.IdTecnicoNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacion == null)
            {
                return NotFound();
            }

            return View(asignacion);
        }

        // POST: Asignacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacion = await _context.Asignaciones.FindAsync(id);
            if (asignacion != null)
            {
                _context.Asignaciones.Remove(asignacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionExists(int id)
        {
            return _context.Asignaciones.Any(e => e.IdAsignacion == id);
        }
    }
}
