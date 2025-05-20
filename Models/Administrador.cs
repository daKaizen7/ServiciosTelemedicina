using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class Administrador : Usuario
{
    public bool? Activo { get; set; }
    public bool? Permisos { get; set; }

}
