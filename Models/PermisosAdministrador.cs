using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class PermisosAdministrador
{
    public int IdAdmin { get; set; }

    public string? Permiso { get; set; }

    public virtual Administrador IdAdminNavigation { get; set; } = null!;
}
