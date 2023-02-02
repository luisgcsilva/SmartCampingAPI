using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly DataContext _context;
        public ReservaRepository(DataContext context)
        {
            _context = context;
        }

        public bool AtualizarReserva(Reserva reserva)
        {
            _context.Update(reserva);
            return Save();
        }

        public bool CriarReserva(Reserva reserva)
        {
            _context.Add(reserva);
            return Save();
        }

        public Reserva GetReserva(int reservaId)
        {
            return _context.Reservas.Where(r => r.ReservaId == reservaId).FirstOrDefault();
        }

        public ICollection<Reserva> GetReservas()
        {
            return _context.Reservas.OrderBy(r => r.DataInicio).ToList();
        }

        public bool ReservaExists(int reservaId)
        {
            return _context.Reservas.Any(r => r.ReservaId == reservaId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
