using System;
using System.Collections.Generic;

namespace Proyecto_PrograAvanzada.Models;

public partial class Tecnico
{
    public int IdTecnico { get; set; }

    public int? IdUsuario { get; set; }

    public string? Especialidad { get; set; }

    public virtual ICollection<Asignacion> Asignaciones { get; set; } = new List<Asignacion>();

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
