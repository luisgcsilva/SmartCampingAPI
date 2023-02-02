using SmartCampingAPI.Models;

namespace SmartCampingAPI.Interfaces
{
    public interface IClienteRepository
    {
        ICollection<Cliente> GetClientes();
        Cliente GetCliente(int clienteId);
        bool ClienteExists(int clienteId);
        ICollection<Reserva> GetReservasPorCliente(int clienteId);
        bool CriarCliente(Cliente cliente);
        bool AtualizarCliente(Cliente cliente);
        bool Save();
    }
}
