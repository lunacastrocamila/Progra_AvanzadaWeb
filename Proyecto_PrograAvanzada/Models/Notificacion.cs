using System;
using System.Collections.Generic;

namespace Proyecto_PrograAvanzada.Models;

public partial class Notificacion
{
    public int IdNotificacion { get; set; }

    public int? IdUsuario { get; set; }

    public int? IdSolicitud { get; set; }

    public string? Mensaje { get; set; }

    public DateTime? FechaNotificacion { get; set; }

    public bool? Visto { get; set; }

    public virtual Solicitud? IdSolicitudNavigation { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
