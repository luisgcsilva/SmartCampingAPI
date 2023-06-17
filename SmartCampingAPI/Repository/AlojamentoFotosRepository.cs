using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class AlojamentoFotosRepository : IAlojamentoFotosRepository
    {
        private readonly DataContext _context;

        public AlojamentoFotosRepository(DataContext context)
        {
            _context = context;
        }

        public bool AtualizarAlojamentoFotos(AlojamentoFotos alojamentoFoto)
        {
            _context.Update(alojamentoFoto);
            return Save();
        }

        public bool CriarAlojamentoFotos(AlojamentoFotos alojamentoFotos)
        {
            _context.Add(alojamentoFotos);
            return Save();
        }

        public ICollection<AlojamentoFotos> GetAlojamentoFotos(int alojamentoid)
        {
            return _context.AlojamentoFotos.Where(a => a.AlojamentoId == alojamentoid).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
