using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface ITipoUtilizadorRepository
    {
        ICollection<TipoUtilizador> GetTipoUtilizadores();
        TipoUtilizador GetTipoUtilizador(int tipoUtilizadorId);
        TipoUtilizador GetTipoUtilizador(string tipo);
        bool TipoUtilizadorExists(int tipoUtilizadorId);
    }
}
