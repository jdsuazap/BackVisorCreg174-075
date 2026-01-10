using Application.SQLContext.SolReciboTecnico.DTOs;
using Application.SQLContext.SolServicioConexionReciboTecnico.DTOs;
using AutoMapper;

namespace Application.SQLContext.SolReciboTecnico.Mapping
{
    internal class SolServicioConexionReciboTecnicoMapper : Profile
    {
        public SolServicioConexionReciboTecnicoMapper()
        {
            CreateMap<Core.Entities.SQLContext.SolServicioConexionReciboTecnico, SolServicioConexionReciboTecnicoDTO>().ReverseMap();
            CreateMap<Core.Entities.SQLContext.SolServicioConexionReciboTecnico, ReciboTecnicoBaseDTO>().ReverseMap();
        }
    }
}
