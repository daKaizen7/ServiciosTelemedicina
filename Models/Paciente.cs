using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class Paciente : Usuario
{

    public string? Direccion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<HistoriasClinica> HistoriasClinicas { get; set; } = new List<HistoriasClinica>();
    public virtual ICollection<SignosVitales> SignosVitales { get; set; } = new List<SignosVitales>();

}
