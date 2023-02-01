namespace SmartCampingAPI.Models
{
    public class Alojamento
    {
        public int AlojamentoId { get; set; }
        public int TipoAlojamentoId { get; set; }
        public string Descricao { get; set; }
        public int Capacidade { get; set; }
        public virtual TipoAlojamento TipoAlojamento { get; set; }
        public virtual ICollection<AlojamentoFoto> AlojamentoFotos { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
