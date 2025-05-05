using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class Antecedente
{
    public int IdAntecedente { get; set; }

    public int? IdHistClin { get; set; }

    public string? Descripcion { get; set; }

    public virtual HistoriasClinica? IdHistClinNavigation { get; set; }
}
