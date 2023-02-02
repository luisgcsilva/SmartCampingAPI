using AutoMapper;
using SmartCampingAPI.Dto;
using SmartCampingAPI.Models;

namespace SmartCampingAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TipoUtilizador, TipoUtilizadorDto>();
            CreateMap<Utilizador, UtilizadorDto>();
            CreateMap<Cliente, ClienteDto>();
            CreateMap<Funcionario, FuncionarioDto>();
            CreateMap<Reserva, ReservaDto>();
        }
    }
}
