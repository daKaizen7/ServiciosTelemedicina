using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiciosTelemedicina.Models
{
    public partial class Encuestas
    {
        [Key]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Url { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        [ForeignKey(nameof(IdUsuarioNavigation))]
        public int Id_Usuario { get; set; }
        public virtual Usuario? IdUsuarioNavigation { get; set; }
    }
}
