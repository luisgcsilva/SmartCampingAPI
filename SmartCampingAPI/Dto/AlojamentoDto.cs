namespace SmartCampingAPI.Dto
{
    public class AlojamentoDto
    {
        public int AlojamentoId { get; set; }
        public int TipoAlojamentoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Capacidade { get; set; }
        public double PrecoNoite { get; set; }
        public string Imagem { get; set; }
    }
}
