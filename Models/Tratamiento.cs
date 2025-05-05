using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class Tratamiento
{
    public int IdTratamiento { get; set; }

    public int? IdDiagnostico { get; set; }

    public int? IdMedicamento { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<HistoriasClinica> HistoriasClinicas { get; set; } = new List<HistoriasClinica>();

    public virtual Diagnostico? IdDiagnosticoNavigation { get; set; }

    public virtual Medicamento? IdMedicamentoNavigation { get; set; }
}
