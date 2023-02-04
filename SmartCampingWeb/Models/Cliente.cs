using System.ComponentModel.DataAnnotations;

namespace SmartCampingWeb.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public int UtilizadorId { get; set; }
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Ñº de Telemovél")]
        public int Telemovel { get; set; }
        [Display(Name = "NIF")]
        public int NIF { get; set; }
        [Display(Name = "Morada")]
        public string Morada { get; set; }
        [Display(Name = "Código-Postal")]
        public string CodPostal { get; set; }
        [Display(Name = "Localidade")]
        public string Localidade { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}
