namespace Application.Oracle.TipoTramiteVisita.Mapping
{
    using Application.Oracle.TipoTramiteVisita.DTOs;
    using AutoMapper;
    using Core.Entities.Oracle;

    internal class TipoTramiteVisitaMapper : Profile
    {
        public TipoTramiteVisitaMapper()
        {
            CreateMap<CregTipoTramiteVisita, TipoTramiteVisitaDTO>().ReverseMap();
        }
    }
}
