using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_PrograAvanzada.Models;

public partial class ReporteSolicitudDetalle
{
    [Key] // Indica que esta propiedad es la clave primaria
    public int IdSolicitud { get; set; }

    public string? NombreUsuario { get; set; }
    public string? Descripcion { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public string? Estado { get; set; }
    public string? NombreTecnico { get; set; }
    public string? MensajeNotificacion { get; set; }
    public DateTime? FechaNotificacion { get; set; }
}