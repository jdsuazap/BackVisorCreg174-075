using Application.SQLContext.SolServicioConexionDatosSuscriptor.DTOs;
using AutoMapper;

namespace Application.SQLContext.SolServicioConexionDatosSuscriptor.Mapping
{
    internal class SolServicioConexionDatosSuscriptorMapper : Profile
    {
        public SolServicioConexionDatosSuscriptorMapper()
        {
            CreateMap<Core.Entities.SQLContext.SolServicioConexionDatosSuscriptor, SolServicioConexionDatosSuscriptorDTO>().ReverseMap();
        }
    }
}
