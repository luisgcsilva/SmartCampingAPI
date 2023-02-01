using Microsoft.EntityFrameworkCore;
using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class TipoUtilizadorRepository : ITipoUtilizadorRepository
    {
        private readonly DataContext _context;
        public TipoUtilizadorRepository(DataContext context)
        {
            _context = context;
        }

        public TipoUtilizador GetTipoUtilizador(int tipoUtilizadorId)
        {
            return _context.TipoUtilizadores.Where(t => t.TipoUtilizadorId == tipoUtilizadorId).FirstOrDefault();
        }

        public TipoUtilizador GetTipoUtilizador(string tipo)
        {
            return _context.TipoUtilizadores.Where(t => t.Tipo == tipo).FirstOrDefault();
        }

        public ICollection<TipoUtilizador> GetTipoUtilizadores()
        {
            return _context.TipoUtilizadores.OrderBy(p => p.TipoUtilizadorId).ToList();
        }

        public bool TipoUtilizadorExists(int tipoUtilizadorId)
        {
            return _context.TipoUtilizadores.Any(t => t.TipoUtilizadorId == tipoUtilizadorId);
        }
    }
}
