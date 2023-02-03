namespace SmartCampingAPI.Models
{
    public class Utilizador
    {
        public int UtilizadorId { get; set; }
        public int TipoUtilizadorId { get; set; }
        public string Email { get; set; }
        public string PalavraPasse { get; set; }
        public virtual TipoUtilizador TipoUtilizador { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
