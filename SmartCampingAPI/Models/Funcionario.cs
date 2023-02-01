namespace SmartCampingAPI.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }
        public int UtilizadorId { get; set; }
        public string Nome { get; set; }
        public int Telemovel { get; set; }
        public string Departamento { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}
