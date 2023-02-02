using Microsoft.EntityFrameworkCore;
using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class MetodoPagamentoRepository : IMetodoPagamentoRepository
    {
        private readonly DataContext _context;
        public MetodoPagamentoRepository(DataContext context)
        {
            _context = context;
        }

        public bool AtualizarMetodoPagamento(MetodoPagamento metodoPagamento)
        {
            _context.Update(metodoPagamento);
            return Save();
        }

        public bool CriarMetodoPagamento(MetodoPagamento metodoPagamento)
        {
            _context.Add(metodoPagamento);
            return Save();
        }

        public MetodoPagamento GetMetodoPagamento(int metodoId)
        {
            return _context.MetodoPagamentos.Where(m => m.MetodoPagamentoId == metodoId).FirstOrDefault();
        }

        public ICollection<MetodoPagamento> GetMetodoPagamentos()
        {
            return _context.MetodoPagamentos.OrderBy(m => m.Metodo).ToList();
        }

        public bool MetodoPagamentoExists(int metodoId)
        {
            return _context.MetodoPagamentos.Any(m => m.MetodoPagamentoId == metodoId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
