using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class Terapeuta : Usuario
{
    public string Cargo { get; set; } = null!;

    public virtual ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();

}
