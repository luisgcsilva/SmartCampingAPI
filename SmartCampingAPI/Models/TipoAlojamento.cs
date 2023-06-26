namespace SmartCampingAPI.Models
{
    public class TipoAlojamento
    {
        public int TipoAlojamentoId { get; set; }
        public string Tipo { get; set; }
        public string Imagem { get; set; }
        public virtual ICollection<Alojamento> Alojamentos { get; set; }    
    }
}
