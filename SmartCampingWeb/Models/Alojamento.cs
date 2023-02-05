using System.ComponentModel.DataAnnotations;

namespace SmartCampingWeb.Models
{
    public class Alojamento
    {
        public int AlojamentoId { get; set; }
        [Display(Name = "Tipo de Alojamento")]
        public int TipoAlojamentoId { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Capacidade")]
        public int Capacidade { get; set; }
        [Display(Name = "Preço por noite")]
        public double PrecoNoite { get; set; }
    }
}
