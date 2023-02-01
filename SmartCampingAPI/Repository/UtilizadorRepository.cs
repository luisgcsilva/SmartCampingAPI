using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;
using System.Linq;

namespace SmartCampingAPI.Repository
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        private readonly DataContext _context;

        public UtilizadorRepository(DataContext context)
        {
            _context = context;
        }
        public Utilizador GetUtilizador(int utilizadorId)
        {
            return _context.Utilizadores.Where(u => u.UtilizadorId == utilizadorId).FirstOrDefault();
        }

        public ICollection<Utilizador> GetUtilizadores()
        {
            return _context.Utilizadores.OrderBy(u => u.UtilizadorId).ToList();
        }

        public bool UtilizadorExists(int utilizadorId)
        {
            return _context.Utilizadores.Any(u => u.UtilizadorId == utilizadorId);

        }
    }
}
