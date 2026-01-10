using Application.SQLContext.SolServicioConexionDetalle.DTOs;
using AutoMapper;

namespace Application.SQLContext.SolServicioConexionDetalle.Mapping
{
    internal class SolServicioConexionDetalleMapper : Profile
    {
        public SolServicioConexionDetalleMapper()
        {
            CreateMap<Core.Entities.SQLContext.SolServicioConexionDetalle, SolServicioConexionDetalleDTO>().ReverseMap();
        }
    }
}
