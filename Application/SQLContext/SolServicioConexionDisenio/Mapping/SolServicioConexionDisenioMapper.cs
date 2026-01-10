using Application.SQLContext.SolServicioConexionDisenio.DTOs;
using AutoMapper;
using Core.CustomEntities.SQLContext;

namespace Application.SQLContext.SolServicioConexionDisenio.Mapping
{
    public class SolServicioConexionDisenioMapper : Profile
    {
        public SolServicioConexionDisenioMapper()
        {
            CreateMap<Core.Entities.SQLContext.SolServicioConexionDisenio, SolServicioConexionDisenioDTO>().ReverseMap();
        }
    }
}
