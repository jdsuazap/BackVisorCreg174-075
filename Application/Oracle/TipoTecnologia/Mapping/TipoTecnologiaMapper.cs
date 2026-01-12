namespace Application.Oracle.TipoTecnologia.Mapping
{
    using Application.Oracle.TipoTecnologia.DTOs;
    using AutoMapper;

    internal class TipoTecnologiaMapper : Profile
    {
        public TipoTecnologiaMapper()
        {
            CreateMap<Core.Entities.Oracle.CregTipoTecnologia, TipoTecnologiaDTO>().ReverseMap();
        }
    }
}
