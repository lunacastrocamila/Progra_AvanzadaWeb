using System;
using System.Collections.Generic;

namespace Proyecto_PrograAvanzada.Models;

public partial class Asignacion
{
    public int IdAsignacion { get; set; }

    public int? IdSolicitud { get; set; }

    public int? IdTecnico { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaCierre { get; set; }

    public virtual Solicitud? IdSolicitudNavigation { get; set; }

    public virtual Tecnico? IdTecnicoNavigation { get; set; }
}
