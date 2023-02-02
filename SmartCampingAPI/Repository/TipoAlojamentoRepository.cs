using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class TipoAlojamentoRepository : ITipoAlojamentoRepository
    {
        private readonly DataContext _context;
        public TipoAlojamentoRepository(DataContext context)
        {
            _context = context; 
        }
        public ICollection<Reserva> GetReservasPorTipoAlojamento(int tipoAlojamentoId)
        {
            return _context.Reservas.Where(
                r => r.Alojamento.TipoAlojamento.TipoAlojamentoId == tipoAlojamentoId).ToList();
        }

        public TipoAlojamento GetTipoAlojamento(int tipoAlojamentoId)
        {
            return _context.TipoAlojamentos.Where(t => t.TipoAlojamentoId == tipoAlojamentoId).FirstOrDefault();
        }

        public ICollection<TipoAlojamento> GetTipoAlojamentos()
        {
            return _context.TipoAlojamentos.OrderBy(t => t.Tipo).ToList();
        }

        public bool TipoAlojamentoExists(int tipoAlojamentoId)
        {
            return _context.TipoAlojamentos.Any(t => t.TipoAlojamentoId == tipoAlojamentoId);
        }
    }
}
