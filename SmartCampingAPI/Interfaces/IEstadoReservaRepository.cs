using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IEstadoReservaRepository
    {
        ICollection<EstadoReserva> GetEstadoReservas();
        EstadoReserva GetEstadoReserva(int estadoResvId);
        ICollection<Reserva> GetReservasPorEstado(int estadoResvId);
        bool EstadoReservaExists(int estadoResvId);
        bool CriarEstadoReserva(EstadoReserva estadoReserva);
        bool AtualizarEstadoReserva(EstadoReserva estadoReserva);
        bool Save();
    }
}
