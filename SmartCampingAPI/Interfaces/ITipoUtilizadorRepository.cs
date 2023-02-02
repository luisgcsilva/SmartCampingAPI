using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface ITipoUtilizadorRepository
    {
        ICollection<TipoUtilizador> GetTipoUtilizadores();
        TipoUtilizador GetTipoUtilizador(int tipoUtilizadorId);
        TipoUtilizador GetTipoUtilizador(string tipo);
        ICollection<Utilizador> GetUtilizadoresPorTipo(int tipoUtilizadorId);
        bool TipoUtilizadorExists(int tipoUtilizadorId);
        bool CriarTipoUtilizador(TipoUtilizador tipoUtilizador);
        bool AtualizarTipoUtilizador(TipoUtilizador tipoUtilizador);
        bool Save();
    }
}
