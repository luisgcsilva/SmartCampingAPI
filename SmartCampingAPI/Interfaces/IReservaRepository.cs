using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IReservaRepository
    {
        ICollection<Reserva> GetReservas();
        Reserva GetReserva(int reservaId);
        bool ReservaExists(int reservaId);
        bool CriarReserva(Reserva reserva);
        bool AtualizarReserva(Reserva reserva);
        bool Save();
    }
}
