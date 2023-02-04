namespace SmartCampingWeb.Models
{
    public class AlojamentoFoto
    {
        public int AlojamentoFotoId { get; set; }
        public int AlojamentoId { get; set; }
        public string Foto { get; set; }
        public virtual Alojamento Alojamento { get; set; }
    }
}
