namespace SmartCampingAPI.Dto
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public int UtilizadorId { get; set; }
        public string Nome { get; set; }
        public int Telemovel { get; set; }
        public int NIF { get; set; }
        public string Morada { get; set; }
        public string CodPostal { get; set; }
        public string Localidade { get; set; }
    }
}
