using System.Data.SqlTypes;

namespace SmartCampingAPI.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int ClienteId { get; set; }
        public int AlojamentoId { get; set; }
        public int MetodoPagamentoId { get; set; }
        public int EstadoReservaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public double PrecoNoite { get; set; }
        public double PrecoTotal { get; set; }
        public double Pagamento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Alojamento Alojamento { get; set; }
        public virtual MetodoPagamento MetodoPagamento { get; set; }
        public virtual EstadoReserva EstadoReserva { get; set; }
    }
}
