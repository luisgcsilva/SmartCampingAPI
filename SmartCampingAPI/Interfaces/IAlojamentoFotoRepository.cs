using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IAlojamentoFotoRepository
    {
        ICollection<AlojamentoFoto> GetAlojamentoFotos(int alojamentoId);
    }
}
