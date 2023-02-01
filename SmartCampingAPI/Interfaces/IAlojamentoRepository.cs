using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IAlojamentoRepository
    {
        ICollection<Alojamento> GetAlojamentos();
    }
}
