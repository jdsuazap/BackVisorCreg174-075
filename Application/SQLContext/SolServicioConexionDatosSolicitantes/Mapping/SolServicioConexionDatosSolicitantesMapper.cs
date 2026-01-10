using Application.SQLContext.SolServicioConexionDatosSolicitantes.DTOs;
using AutoMapper;

namespace Application.SQLContext.SolServicioConexionDatosSolicitantes.Mapping
{
    internal class SolServicioConexionDatosSolicitantesMapper : Profile
    {
        public SolServicioConexionDatosSolicitantesMapper()
        {
            CreateMap<Core.Entities.SQLContext.SolServicioConexionDatosSolicitante, SolServicioConexionDatosSolicitantesDTO>().ReverseMap();
        }
    }
}
