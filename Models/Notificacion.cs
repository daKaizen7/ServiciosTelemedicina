using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class Notificacion
{
    public int IdNotificacion { get; set; }

    public int? IdUsuario { get; set; }

    public string Mensaje { get; set; } = null!;

    public DateOnly Fecha { get; set; }

    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
