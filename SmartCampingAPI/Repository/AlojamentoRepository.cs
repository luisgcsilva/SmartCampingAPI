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

        public bool AtualizarAlojamento(Alojamento alojamento)
        {
            _context.Update(alojamento);
            return Save();
        }

        public bool CriarAlojamento(Alojamento alojamento)
        {
            _context.Add(alojamento);
            return Save();
        }

        public ICollection<Alojamento> GetAlojamentosPorTipo(int tipoAlojamentoId)
        {
            return _context.Alojamentos.Where(a => a.TipoAlojamentoId == tipoAlojamentoId).ToList();
        }

        public Alojamento GetAlojamento(int alojamentoid)
        {
            return _context.Alojamentos.Where(a => a.AlojamentoId == alojamentoid).FirstOrDefault();
        }

        public ICollection<Alojamento> GetAlojamentos()
        {
            return _context.Alojamentos.OrderBy(a => a.TipoAlojamentoId).ToList();
        }

        public ICollection<Reserva> GetReservasPorAlojamento(int alojamentoId)
        {
            return _context.Reservas.Where(r => r.AlojamentoId == alojamentoId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
