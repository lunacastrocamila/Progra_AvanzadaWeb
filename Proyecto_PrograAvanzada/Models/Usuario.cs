using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_PrograAvanzada.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(35, ErrorMessage = "El nombre no puede exceder los 35 caracteres.")]
    public string? Nombre { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [StringLength(35, ErrorMessage = "El apellido no puede exceder los 50 caracteres.")]
    public string? Apellido { get; set; }

    [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
    [EmailAddress(ErrorMessage = "El formato del correo electrónico es inválido.")]
    public string? CorreoElectronico { get; set; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    [StringLength(15, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 15 caracteres.")]
    public string? Contraseña { get; set; }

    [Required(ErrorMessage = "El rol es obligatorio.")]
    [RegularExpression(@"^(Administrador|Cliente|Técnico)$", ErrorMessage = "El rol debe ser 'Administrador', 'Cliente' o 'Técnico'.")]
    public string? Rol { get; set; }

    public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();

    public virtual ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();

    public virtual Tecnico? Tecnico { get; set; }
}
