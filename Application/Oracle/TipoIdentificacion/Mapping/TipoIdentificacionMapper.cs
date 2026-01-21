namespace Application.Oracle.TipoIdentificacion.Mapping
{
    using Application.Oracle.TipoIdentificacion.DTOs;
    using AutoMapper;
    using Core.Entities.Oracle;

    internal class TipoIdentificacionMapper : Profile
    {
        public TipoIdentificacionMapper()
        {
            CreateMap<CregTipoIdentificacion, TipoIdentificacionDTO>().ReverseMap();
        }
    }
}
