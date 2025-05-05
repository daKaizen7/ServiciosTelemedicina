using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class Diagnostico
{
    public int IdDiagnostico { get; set; }

    public int? IdTerapeuta { get; set; }

    public int? IdCita { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<HistoriasClinica> HistoriasClinicas { get; set; } = new List<HistoriasClinica>();

    public virtual Cita? IdCitaNavigation { get; set; }

    public virtual Terapeuta? IdTerapeutaNavigation { get; set; }

    public virtual ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
}
