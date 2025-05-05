using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class Informe
{
    public int IdInforme { get; set; }

    public int? IdHistClin { get; set; }

    public DateOnly Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual HistoriasClinica? IdHistClinNavigation { get; set; }
}
