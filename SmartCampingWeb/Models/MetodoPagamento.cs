namespace SmartCampingAPI.Models
{
    public class MetodoPagamento
    {
        public int MetodoPagamentoId { get; set; }
        public string Metodo { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
