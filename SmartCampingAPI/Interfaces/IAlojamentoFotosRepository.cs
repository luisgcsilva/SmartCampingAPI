using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IAlojamentoFotosRepository
    {
        ICollection<AlojamentoFotos> GetAlojamentoFotos(int alojamentoid);
        bool CriarAlojamentoFotos(AlojamentoFotos alojamento);
        bool AtualizarAlojamentoFotos(AlojamentoFotos alojamentoFotos);
        bool Save();
    }
}
