namespace SmartCampingAPI.Models
{
    public class TipoUtilizador
    {
        public int TipoUtilizadorId { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<Utilizador> Utilizadores { get; set; }
    }
}
