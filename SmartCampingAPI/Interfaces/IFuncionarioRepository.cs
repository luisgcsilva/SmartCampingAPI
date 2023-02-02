using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IFuncionarioRepository
    {
        ICollection<Funcionario> GetFuncionarios();

        Funcionario GetFuncionario(int funcionarioId);
        bool FuncionarioExtists(int funcionarioId);
    }
}
