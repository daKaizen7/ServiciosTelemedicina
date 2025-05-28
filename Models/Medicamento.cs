using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServiciosTelemedicina.Models;

public partial class Medicamento
{
    public int IdMedicamento { get; set; }

    public string Nombre { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
}
