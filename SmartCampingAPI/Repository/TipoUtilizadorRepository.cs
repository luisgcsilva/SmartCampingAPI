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

        public bool ApagarTipoUtilizador(TipoUtilizador tipoutilizador)
        {
            _context.Remove(tipoutilizador);
            return Save();
        }

        public bool AtualizarTipoUtilizador(TipoUtilizador tipoUtilizador)
        {
            _context.Update(tipoUtilizador);
            return Save();
        }

        public bool CriarTipoUtilizador(TipoUtilizador tipoUtilizador)
        {
            _context.Add(tipoUtilizador);
            return Save();
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

        public ICollection<Utilizador> GetUtilizadoresPorTipo(int tipoUtilizadorId)
        {
            return _context.Utilizadores.Where(
                u => u.TipoUtilizadorId == tipoUtilizadorId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool TipoUtilizadorExists(int tipoUtilizadorId)
        {
            return _context.TipoUtilizadores.Any(t => t.TipoUtilizadorId == tipoUtilizadorId);
        }
    }
}
