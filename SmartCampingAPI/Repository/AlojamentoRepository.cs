using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class AlojamentoRepository : IAlojamentoRepository
    {
        private readonly DataContext _context;

        public AlojamentoRepository(DataContext context)
        {
            _context = context;
        }

        public bool AlojamentoExists(int alojamentoid)
        {
            return _context.Alojamentos.Any(a => a.AlojamentoId == alojamentoid);
        }

        public Alojamento GetAlojamento(int alojamentoid)
        {
            return _context.Alojamentos.Where(a => a.AlojamentoId == alojamentoid).FirstOrDefault();
        }

        public ICollection<Alojamento> GetAlojamentos()
        {
            return _context.Alojamentos.OrderBy(a => a.AlojamentoId).ToList();
        }

        public ICollection<Reserva> GetReservasPorAlojamento(int alojamentoId)
        {
            return _context.Reservas.Where(r => r.AlojamentoId == alojamentoId).ToList();
        }
    }
}
