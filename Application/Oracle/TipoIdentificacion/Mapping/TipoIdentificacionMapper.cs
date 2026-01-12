using Application.Oracle.TipoIdentificacion.DTOs;
using AutoMapper;

namespace Application.Oracle.TipoIdentificacion.Mapping
{
    internal class TipoIdentificacionMapper : Profile
    {
        public TipoIdentificacionMapper()
        {
            CreateMap<Core.Entities.SQLContext.TipoIdentificacion, TipoIdentificacionDTO>().ReverseMap();
        }
    }
}
