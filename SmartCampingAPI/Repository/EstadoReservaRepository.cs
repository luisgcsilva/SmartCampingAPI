using Microsoft.EntityFrameworkCore;
using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class EstadoReservaRepository : IEstadoReservaRepository
    {
        private readonly DataContext _context;

        public EstadoReservaRepository(DataContext context)
        {
            _context = context;
        }

        public bool AtualizarEstadoReserva(EstadoReserva estadoReserva)
        {
            _context.Update(estadoReserva);
            return Save();
        }

        public bool CriarEstadoReserva(EstadoReserva estadoReserva)
        {
            _context.Add(estadoReserva);
            return Save();
        }

        public bool EstadoReservaExists(int estadoResvId)
        {
            return _context.EstadoReservas.Any(e => e.EstadoReservaId == estadoResvId);
        }

        public EstadoReserva GetEstadoReserva(int estadoResvId)
        {
            return _context.EstadoReservas.Where(e => e.EstadoReservaId == estadoResvId).FirstOrDefault();
        }

        public ICollection<EstadoReserva> GetEstadoReservas()
        {
            return _context.EstadoReservas.OrderBy(e => e.Estado).ToList();
        }

        public ICollection<Reserva> GetReservasPorEstado(int estadoResvId)
        {
            return _context.Reservas.Where(r => r.EstadoReservaId == estadoResvId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
