using SmartCampingAPI.Dto;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IFuncionarioRepository
    {
        ICollection<Funcionario> GetFuncionarios();

        Funcionario GetFuncionario(int funcionarioId);
        bool FuncionarioExtists(int funcionarioId);
        bool CriarFuncionario(Funcionario funcionario);
        bool AtualizarFuncionario(Funcionario funcionario);
        bool Save();
    }
}
