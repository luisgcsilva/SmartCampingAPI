namespace SmartCampingAPI.Dto
{
    public class ReservaDto
    {
        public int ReservaId { get; set; }
        public int ClienteId { get; set; }
        public int AlojamentoId { get; set; }
        public int MetodoPagamentoId { get; set; }
        public int EstadoReservaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public double PrecoNoite { get; set; }
        public double PrecoTotal { get; set; }
        public double Pagamento { get; set; }
    }
}
