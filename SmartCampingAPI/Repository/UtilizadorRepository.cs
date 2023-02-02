using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class UtilizadorRepository : IUtilizadorRepository
    {
        private readonly DataContext _context;

        public UtilizadorRepository(DataContext context)
        {
            _context = context;
        }

        public bool AtualizarUtilizador(Utilizador utilizador)
        {
            _context.Update(utilizador);
            return Save();
        }

        public bool CriarUtilizador(Utilizador utilizador)
        {
            //Change Tracker
            //add, update, modifying
            _context.Add(utilizador);
            return Save();
        }

        public Utilizador GetUtilizador(int utilizadorId)
        {
            return _context.Utilizadores.Where(u => u.UtilizadorId == utilizadorId).FirstOrDefault();
        }

        public ICollection<Utilizador> GetUtilizadores()
        {
            return _context.Utilizadores.OrderBy(u => u.UtilizadorId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UtilizadorExists(int utilizadorId)
        {
            return _context.Utilizadores.Any(u => u.UtilizadorId == utilizadorId);

        }
    }
}
