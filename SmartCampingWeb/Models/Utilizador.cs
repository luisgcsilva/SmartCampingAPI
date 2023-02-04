using System.ComponentModel.DataAnnotations;

namespace SmartCampingWeb.Models
{
    public class Utilizador
    {
        public int UtilizadorId { get; set; }
        [Display(Name = "Tipo de Utilizador")]
        public int TipoUtilizadorId { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Palavra-Passe")]
        public string PalavraPasse { get; set; }
    }
}
