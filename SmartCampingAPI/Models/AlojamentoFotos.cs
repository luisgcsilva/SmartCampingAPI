namespace SmartCampingAPI.Models
{
    public class AlojamentoFotos
    {
        public int AlojamentoFotosId { get; set; }
        public int AlojamentoId { get; set; }
        public string Imagem { get; set; }
        public virtual ICollection<Alojamento> Alojamentos { get; set; }
    }
}
