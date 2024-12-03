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
    public class HistorialEstadoController : Controller
    {
        private readonly ServiciosSoporteContext _context;

        public HistorialEstadoController(ServiciosSoporteContext context)
        {
            _context = context;
        }

        // GET: HistorialEstado
        public async Task<IActionResult> Index()
        {
            var serviciosSoporteContext = _context.HistorialEstados.Include(h => h.IdSolicitudNavigation);
            return View(await serviciosSoporteContext.ToListAsync());
        }

        // GET: HistorialEstado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialEstado = await _context.HistorialEstados
                .Include(h => h.IdSolicitudNavigation)
                .FirstOrDefaultAsync(m => m.IdHistorial == id);
            if (historialEstado == null)
            {
                return NotFound();
            }

            return View(historialEstado);
        }

        // GET: HistorialEstado/Create
        public IActionResult Create()
        {
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitudes, "IdSolicitud", "IdSolicitud");
            return View();
        }

        // POST: HistorialEstado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHistorial,IdSolicitud,EstadoAnterior,EstadoNuevo,FechaCambio,Comentarios")] HistorialEstado historialEstado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historialEstado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitudes, "IdSolicitud", "IdSolicitud", historialEstado.IdSolicitud);
            return View(historialEstado);
        }

        // GET: HistorialEstado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialEstado = await _context.HistorialEstados.FindAsync(id);
            if (historialEstado == null)
            {
                return NotFound();
            }
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitudes, "IdSolicitud", "IdSolicitud", historialEstado.IdSolicitud);
            return View(historialEstado);
        }

        // POST: HistorialEstado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHistorial,IdSolicitud,EstadoAnterior,EstadoNuevo,FechaCambio,Comentarios")] HistorialEstado historialEstado)
        {
            if (id != historialEstado.IdHistorial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historialEstado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialEstadoExists(historialEstado.IdHistorial))
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
            ViewData["IdSolicitud"] = new SelectList(_context.Solicitudes, "IdSolicitud", "IdSolicitud", historialEstado.IdSolicitud);
            return View(historialEstado);
        }

        // GET: HistorialEstado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var historialEstado = await _context.HistorialEstados
                .Include(h => h.IdSolicitudNavigation)
                .FirstOrDefaultAsync(m => m.IdHistorial == id);
            if (historialEstado == null)
            {
                return NotFound();
            }

            return View(historialEstado);
        }

        // POST: HistorialEstado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historialEstado = await _context.HistorialEstados.FindAsync(id);
            if (historialEstado != null)
            {
                _context.HistorialEstados.Remove(historialEstado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialEstadoExists(int id)
        {
            return _context.HistorialEstados.Any(e => e.IdHistorial == id);
        }
    }
}
