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
        }
    }
}
