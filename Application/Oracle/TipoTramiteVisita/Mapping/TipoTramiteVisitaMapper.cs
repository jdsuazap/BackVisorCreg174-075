namespace Application.Oracle.TipoTramiteVisita.Mapping
{
    using Application.Oracle.TipoTramiteVisita.DTOs;
    using AutoMapper;
    internal class TipoTramiteVisitaMapper : Profile
    {
        public TipoTramiteVisitaMapper()
        {
            CreateMap<Core.Entities.Oracle.CregTipoTramiteVisita, TipoTramiteVisitaDTO>().ReverseMap();
        }
    }
}
