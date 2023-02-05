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

        public bool AtualizarCliente(Cliente cliente)
        {
            _context.Update(cliente);
            return Save();
        }

        public bool ClienteExists(int clienteId)
        {
            return _context.Clientes.Any(c => c.ClienteId == clienteId);
        }

        public bool CriarCliente(Cliente cliente)
        {
            _context.Add(cliente);
            return Save();
        }

        public Cliente GetCliente(int clienteId)
        {
            return _context.Clientes.Where(c => c.ClienteId == clienteId).FirstOrDefault();
        }

        public ICollection<Cliente> GetClientes()
        {
            return _context.Clientes.OrderBy(c => c.Nome).ToList();
        }

        public Cliente GetClienteUtilizador(int utilizadorId)
        {
            return _context.Clientes.Where(c => c.UtilizadorId == utilizadorId).FirstOrDefault();
        }

        public ICollection<Reserva> GetReservasPorCliente(int clienteId)
        {
            return _context.Reservas.Where(r => r.ClienteId == clienteId).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
