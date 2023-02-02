using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IEstadoReservaRepository
    {
        ICollection<EstadoReserva> GetEstadoReservas();
        EstadoReserva GetEstadoReserva(int estadoResvId);
        bool EstadoReservaExists(int estadoResvId);
    }
}
