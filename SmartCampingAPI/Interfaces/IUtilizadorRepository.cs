using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IUtilizadorRepository
    {
        ICollection<Utilizador> GetUtilizadores();
        Utilizador GetUtilizador(int utilizadorId);
        bool UtilizadorExists(int utilizadorId);
        bool CriarUtilizador(Utilizador utilizador);
        bool AtualizarUtilizador(Utilizador utilizador);
        bool Save();
    }
}
