using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace SmartCampingWeb.Models
{
    public class Reserva
    {
        [Display(Name = "ID da Reserva")]
        public int ReservaId { get; set; }
        [Display(Name = "ID do Cliente")]
        public int ClienteId { get; set; }
        [Display(Name = "Alojamento")]
        public int AlojamentoId { get; set; }
        [Display(Name = "Método de Pagamento")]
        public int MetodoPagamentoId { get; set; }
        [Display(Name = "Estado da Reserva")]
        public int EstadoReservaId { get; set; }
        [Display(Name = "Dia de entrada")]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Dia de saída")]
        [DataType(DataType.Date)]
        public DateTime DataFim { get; set; }
        [Display(Name = "Preço total")]
        public double PrecoTotal { get; set; }
        [Display(Name = "Já pago")]
        public double Pagamento { get; set; }
    }
}
