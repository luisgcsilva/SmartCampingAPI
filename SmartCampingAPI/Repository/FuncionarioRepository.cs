using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly DataContext _context;
        public FuncionarioRepository(DataContext context)
        {
            _context = context;
        }
        public bool FuncionarioExtists(int funcionarioId)
        {
            return _context.Funcionarios
                .Any(f => f.FuncionarioId == funcionarioId);    
        }

        public Funcionario GetFuncionario(int funcionarioId)
        {
            return _context.Funcionarios.Where(f => f.FuncionarioId == funcionarioId).FirstOrDefault();
        }

        public ICollection<Funcionario> GetFuncionarios()
        {
            return _context.Funcionarios.OrderBy(f => f.Nome).ToList();
        }
    }
}
