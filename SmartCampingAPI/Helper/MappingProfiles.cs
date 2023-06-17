using AutoMapper;
using SmartCampingAPI.Dto;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Alojamento, AlojamentoDto>();
            CreateMap<AlojamentoDto, Alojamento>();
            CreateMap<AlojamentoFotos, AlojamentoFotosDto>();
            CreateMap<AlojamentoFotosDto, AlojamentoFotos>();
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>(); 
            CreateMap<EstadoReserva, EstadoReservaDto>();
            CreateMap<EstadoReservaDto, EstadoReserva>();
            CreateMap<Funcionario, FuncionarioDto>();
            CreateMap<FuncionarioDto, Funcionario>();
            CreateMap<MetodoPagamento, MetodoPagamentoDto>();
            CreateMap<MetodoPagamentoDto, MetodoPagamento>();
            CreateMap<Reserva, ReservaDto>();
            CreateMap<ReservaDto, Reserva>();
            CreateMap<TipoAlojamento, TipoAlojamentoDto>();
            CreateMap<TipoAlojamentoDto, TipoAlojamento>();
            CreateMap<TipoUtilizador, TipoUtilizadorDto>();
            CreateMap<TipoUtilizadorDto, TipoUtilizador>();
            CreateMap<Utilizador, UtilizadorDto>();
            CreateMap<UtilizadorDto, Utilizador>();
        }
    }
}
