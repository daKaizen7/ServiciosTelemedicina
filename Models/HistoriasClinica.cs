using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class HistoriasClinica
{
    public int IdHistClin { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdDiagnostico { get; set; }

    public int? IdTratamiento { get; set; }

    public virtual ICollection<Antecedente> Antecedentes { get; set; } = new List<Antecedente>();

    public virtual Diagnostico? IdDiagnosticoNavigation { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }

    public virtual Tratamiento? IdTratamientoNavigation { get; set; }

    public virtual ICollection<Informe> Informes { get; set; } = new List<Informe>();
}
