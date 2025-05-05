using System;
using System.Collections.Generic;

namespace ServiciosTelemedicina.Models;

public partial class Cita
{
    public int IdCita { get; set; }

    public int? IdPaciente { get; set; }

    public DateOnly Fecha { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();

    public virtual Paciente? IdPacienteNavigation { get; set; }
}
