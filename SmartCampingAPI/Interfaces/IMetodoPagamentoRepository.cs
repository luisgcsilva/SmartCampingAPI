using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IMetodoPagamentoRepository
    {
        ICollection<MetodoPagamento> GetMetodoPagamentos();
        MetodoPagamento GetMetodoPagamento(int metodoId);
        bool MetodoPagamentoExists(int metodoId);
    }
}
