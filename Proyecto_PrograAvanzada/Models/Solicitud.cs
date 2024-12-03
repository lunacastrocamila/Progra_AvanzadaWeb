using System;
using System.Collections.Generic;

namespace Proyecto_PrograAvanzada.Models;

public partial class Solicitud
{
    public int IdSolicitud { get; set; }

    public int? IdUsuario { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public string? Estado { get; set; }

    public string? Prioridad { get; set; }

    public virtual ICollection<Asignacion> Asignaciones { get; set; } = new List<Asignacion>();

    public virtual ICollection<HistorialEstado> HistorialEstados { get; set; } = new List<HistorialEstado>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
}
