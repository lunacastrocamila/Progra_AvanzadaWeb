using System;
using System.Collections.Generic;

namespace Proyecto_PrograAvanzada.Models;

public partial class HistorialEstado
{
    public int IdHistorial { get; set; }

    public int? IdSolicitud { get; set; }

    public string? EstadoAnterior { get; set; }

    public string? EstadoNuevo { get; set; }

    public DateTime? FechaCambio { get; set; }

    public string? Comentarios { get; set; }

    public virtual Solicitud? IdSolicitudNavigation { get; set; }
}
