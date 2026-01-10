using Application.SQLContext.SolServicioConexionPredio.DTOs;
using AutoMapper;

namespace Application.SQLContext.SolServicioConexionPredio.Mapping
{
    internal class SolServicioConexionPredioMapper : Profile
    {
        public SolServicioConexionPredioMapper()
        {
            CreateMap<Core.Entities.SQLContext.SolServicioConexionPredio, SolServicioConexionPredioDTO>().ReverseMap();
        }
    }
}
