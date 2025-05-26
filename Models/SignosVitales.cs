namespace ServiciosTelemedicina.Models
{
    public partial class SignosVitales
    {
        public int IdSignos { get; set; }

        public double altura { get; set; }

        public double peso { get; set; }

        public double masaCorporal { get; set; }

        public double Temperatura { get; set; }

        public int FrecuenciaRespiratoria { get; set; }

        public int PresionArterial { get; set; }

        public int frecuenciaCardiaca { get; set; }

        public int pacienteId { get; set; }

        public virtual Paciente? IdPacienteNavigation { get; set; }
    }
}
