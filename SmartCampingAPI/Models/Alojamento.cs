namespace SmartCampingAPI.Models
{
    public class Alojamento
    {
        public int AlojamentoId { get; set; }
        public int TipoAlojamentoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Capacidade { get; set; }
        public double PrecoNoite { get; set; }
        public string Imagem { get; set; }
        public virtual TipoAlojamento TipoAlojamento { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
        public virtual ICollection<AlojamentoFotos> AlojamentoFotos { get; set; }
    }
}
