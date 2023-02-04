using System.ComponentModel.DataAnnotations;

namespace SmartCampingWeb.Models
{
    public class MetodoPagamento
    {
        public int MetodoPagamentoId { get; set; }
        [Display(Name = "Método de Pagamento")]
        public string Metodo { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
