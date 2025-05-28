using System.ComponentModel.DataAnnotations;

namespace ServiciosTelemedicina.Models
{
    public partial class Encuestas
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Url { get; set; }
        public DateOnly FechaCreacion { get; set; }
        public bool Activo { get; set; }
        public int Id_Usuario { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
