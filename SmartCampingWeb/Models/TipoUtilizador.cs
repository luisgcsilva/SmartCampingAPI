using System.ComponentModel.DataAnnotations;

namespace SmartCampingWeb.Models
{
    public class TipoUtilizador
    {
        public int TipoUtilizadorId { get; set; }
        [Display(Name = "Tipo de Utilizador")]
        public string Tipo { get; set; }
        public virtual ICollection<Utilizador> Utilizadores { get; set; }
    }
}
