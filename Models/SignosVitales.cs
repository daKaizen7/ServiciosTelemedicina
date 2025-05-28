using System.ComponentModel.DataAnnotations;

namespace ServiciosTelemedicina.Models
{
    public partial class SignosVitales
    {
        [Key]
        public int IdSignos { get; set; }

        public decimal altura { get; set; }

        public decimal peso { get; set; }

        public decimal masaCorporal { get; set; }

        public decimal Temperatura { get; set; }

        public int FrecuenciaRespiratoria { get; set; }

        public int PresionArterial { get; set; }

        public int frecuenciaCardiaca { get; set; }

        public int pacienteId { get; set; }

        public virtual Paciente? IdPacienteNavigation { get; set; }
    }
}
