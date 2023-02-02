using SmartCampingAPI.Data;
using SmartCampingAPI.Interfaces;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context) 
        {
            _context= context;
        }

        public bool ClienteExists(int clienteId)
        {
            return _context.Clientes.Any(c => c.ClienteId == clienteId);
        }

        public Cliente GetCliente(int clienteId)
        {
            return _context.Clientes.Where(c => c.ClienteId == clienteId).FirstOrDefault();
        }

        public ICollection<Cliente> GetClientes()
        {
            return _context.Clientes.OrderBy(c => c.Nome).ToList();
        }
    }
}
