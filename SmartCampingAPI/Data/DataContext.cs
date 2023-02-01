using Microsoft.EntityFrameworkCore;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Alojamento> Alojamentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EstadoReserva> EstadoReservas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<MetodoPagamento> MetodoPagamentos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipoAlojamento> TipoAlojamentos { get; set; }
        public DbSet<TipoUtilizador> TipoUtilizadores { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<AlojamentoFoto> AlojamentoFoto { get; set; }
    }
}
