using System.ComponentModel.DataAnnotations;

namespace SmartCampingWeb.Models
{
    public class TipoAlojamento
    {
        public int TipoAlojamentoId { get; set; }
        [Display(Name = "Tipo de Alojamento")]
        public string Tipo { get; set; } 
    }
}
