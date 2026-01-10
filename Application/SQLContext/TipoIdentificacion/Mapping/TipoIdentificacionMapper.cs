using Application.SQLContext.TipoIdentificacion.DTOs;
using AutoMapper;

namespace Application.SQLContext.TipoIdentificacion.Mapping
{
    internal class TipoIdentificacionMapper : Profile
    {
        public TipoIdentificacionMapper()
        {
            CreateMap<Core.Entities.SQLContext.TipoIdentificacion, TipoIdentificacionDTO>().ReverseMap();
        }
    }
}
