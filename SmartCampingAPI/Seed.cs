using SmartCampingAPI.Data;
using SmartCampingAPI.Models;

namespace SmartCampingAPI
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Reservas.Any())
            {
                var reservas = new List<Reserva>()
                {
                    new Reserva()
                    {
                        DataInicio = new DateTime(2023, 3, 1),
                        DataFim = new DateTime(2023, 3, 3),
                        PrecoNoite = 23.10,
                        PrecoTotal = 46.20,
                        Pagamento = 46.20,
                        Cliente = new Cliente()
                        {
                            Nome = "Luis Silva",
                            Telemovel = 987654321,
                            NIF = 123456789,
                            Morada = "Rua do Troco, Lote 174, Brunheiras",
                            CodPostal = "7645-023",
                            Localidade = "Vila Nova de Milfontes",
                            Utilizador = new Utilizador()
                            {
                                Email = "luis@gmail.com",
                                PalavraPasse = "123456789",
                                TipoUtilizador = new TipoUtilizador()
                                {
                                    Tipo = "Cliente"
                                }
                            },
                        },
                        Alojamento = new Alojamento()
                        {
                            Descricao = "Um Bungalow com 2 quartos.",
                            Capacidade = 4,
                            TipoAlojamento = new TipoAlojamento()
                            {
                                Tipo = "Bungalow"
                            }
                        },
                        MetodoPagamento = new MetodoPagamento()
                        {
                            Metodo = "Multibanco"
                        },
                        EstadoReserva = new EstadoReserva()
                        {
                            Estado = "Em aberto"
                        }
                    }
                };            
                dataContext.Reservas.AddRange(reservas);
                dataContext.SaveChanges();
            };
        }
    }
}
