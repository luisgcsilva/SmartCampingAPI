using SmartCampingAPI.Data;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class AlojamentoRepository
    {
        private readonly DataContext _context;

        public AlojamentoRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Alojamento> GetAlojamentos()
        {
            return _context.Alojamentos.OrderBy(a => a.AlojamentoId).ToList();
        }
    }
}
