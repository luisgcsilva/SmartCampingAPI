using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IAlojamentoRepository
    {
        ICollection<Alojamento> GetAlojamentos();
        Alojamento GetAlojamento(int alojamentoid);
        ICollection<Reserva> GetReservasPorAlojamento(int alojamentoId);
        bool AlojamentoExists(int alojamentoid);
        bool CriarAlojamento(Alojamento alojamento);
        bool AtualizarAlojamento(Alojamento alojamento);
        bool Save();
    }
}
