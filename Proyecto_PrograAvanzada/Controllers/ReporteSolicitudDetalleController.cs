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
    public class ReporteSolicitudDetalleController : Controller
    {
        private readonly ServiciosSoporteContext _context;

        public ReporteSolicitudDetalleController(ServiciosSoporteContext context)
        {
            _context = context;
        }

        // GET: ReporteSolicitudDetalle
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReporteSolicitudDetalle.ToListAsync());
        }

        // GET: ReporteSolicitudDetalle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteSolicitudDetalle = await _context.ReporteSolicitudDetalle
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (reporteSolicitudDetalle == null)
            {
                return NotFound();
            }

            return View(reporteSolicitudDetalle);
        }

        // GET: ReporteSolicitudDetalle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReporteSolicitudDetalle/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSolicitud,NombreUsuario,Descripcion,FechaCreacion,Estado,NombreTecnico,MensajeNotificacion,FechaNotificacion")] ReporteSolicitudDetalle reporteSolicitudDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reporteSolicitudDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reporteSolicitudDetalle);
        }

        // GET: ReporteSolicitudDetalle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteSolicitudDetalle = await _context.ReporteSolicitudDetalle.FindAsync(id);
            if (reporteSolicitudDetalle == null)
            {
                return NotFound();
            }
            return View(reporteSolicitudDetalle);
        }

        // POST: ReporteSolicitudDetalle/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSolicitud,NombreUsuario,Descripcion,FechaCreacion,Estado,NombreTecnico,MensajeNotificacion,FechaNotificacion")] ReporteSolicitudDetalle reporteSolicitudDetalle)
        {
            if (id != reporteSolicitudDetalle.IdSolicitud)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reporteSolicitudDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReporteSolicitudDetalleExists(reporteSolicitudDetalle.IdSolicitud))
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
            return View(reporteSolicitudDetalle);
        }

        // GET: ReporteSolicitudDetalle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reporteSolicitudDetalle = await _context.ReporteSolicitudDetalle
                .FirstOrDefaultAsync(m => m.IdSolicitud == id);
            if (reporteSolicitudDetalle == null)
            {
                return NotFound();
            }

            return View(reporteSolicitudDetalle);
        }

        // POST: ReporteSolicitudDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reporteSolicitudDetalle = await _context.ReporteSolicitudDetalle.FindAsync(id);
            if (reporteSolicitudDetalle != null)
            {
                _context.ReporteSolicitudDetalle.Remove(reporteSolicitudDetalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReporteSolicitudDetalleExists(int id)
        {
            return _context.ReporteSolicitudDetalle.Any(e => e.IdSolicitud == id);
        }

        public async Task<IActionResult> SolicitudesPorTecnico(int pageNumber = 1, int pageSize = 10)
        {
            // Validar que el usuario sea administrador
            if (HttpContext.Session.GetString("UserRole") != "Administrador")
            {
                return RedirectToAction("Login", "Usuario");
            }

            // Consulta para obtener los detalles del reporte
            var reportData = await _context.Asignaciones
                .Include(a => a.IdSolicitudNavigation)
                    .ThenInclude(s => s.IdUsuarioNavigation)
                .Include(a => a.IdTecnicoNavigation)
                    .ThenInclude(t => t.IdUsuarioNavigation)
                .Include(a => a.IdSolicitudNavigation.Notificaciones)
                .Select(a => new ReporteSolicitudDetalle
                {
                    IdSolicitud = a.IdSolicitudNavigation.IdSolicitud,
                    NombreUsuario = a.IdSolicitudNavigation.IdUsuarioNavigation != null
                        ? a.IdSolicitudNavigation.IdUsuarioNavigation.Nombre
                        : "Usuario Desconocido",
                    Descripcion = a.IdSolicitudNavigation.Descripcion,
                    FechaCreacion = a.IdSolicitudNavigation.FechaCreacion ?? DateTime.MinValue,
                    Estado = a.IdSolicitudNavigation.Estado,
                    NombreTecnico = a.IdTecnicoNavigation.IdUsuarioNavigation != null
                        ? a.IdTecnicoNavigation.IdUsuarioNavigation.Nombre
                        : "Técnico Desconocido",
                    MensajeNotificacion = a.IdSolicitudNavigation.Notificaciones.Any()
                        ? "Notificación Enviada"
                        : "Sin Notificación",
                    FechaNotificacion = a.IdSolicitudNavigation.Notificaciones
                        .OrderByDescending(n => n.FechaNotificacion)
                        .Select(n => n.FechaNotificacion)
                        .FirstOrDefault()
                })
                .OrderByDescending(r => r.FechaCreacion)
                .ToListAsync();

            // Paginación
            var paginatedData = reportData
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)reportData.Count / pageSize);
            ViewBag.CurrentPage = pageNumber;

            return View(paginatedData);
        }
    }
}
