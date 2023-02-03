namespace SmartCampingAPI.Models
{
    public class EstadoReserva
    {
        public int EstadoReservaId { get; set; }
        public string Estado { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
