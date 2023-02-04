using System.ComponentModel.DataAnnotations;

namespace SmartCampingWeb.Models
{
    public class EstadoReserva
    {
        public int EstadoReservaId { get; set; }
        [Display(Name = "Estado da Reserva")]
        public string Estado { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
