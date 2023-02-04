using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace SmartCampingWeb.Models
{
    public class Reserva
    {
        public int ReservaId { get; set; }
        public int ClienteId { get; set; }
        [Display(Name = "Alojamento")]
        public int AlojamentoId { get; set; }
        [Display(Name = "Método de Pagamento")]
        public int MetodoPagamentoId { get; set; }
        [Display(Name = "Estado da Reserva")]
        public int EstadoReservaId { get; set; }
        [Display(Name = "Dia de entrada")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Dia de saída")]
        public DateTime DataFim { get; set; }
        [Display(Name = "Preço por noite")]
        public double PrecoNoite { get; set; }
        [Display(Name = "Preço total")]
        public double PrecoTotal { get; set; }
        [Display(Name = "Já pago")]
        public double Pagamento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Alojamento Alojamento { get; set; }
        public virtual MetodoPagamento MetodoPagamento { get; set; }
        public virtual EstadoReserva EstadoReserva { get; set; }
    }
}
