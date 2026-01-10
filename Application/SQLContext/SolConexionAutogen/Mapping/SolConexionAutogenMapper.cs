namespace Application.SQLContext.SolConexionAutogen.Mapping
{
    using Application.SQLContext.SolConexionAutogen.DTOs;
    using AutoMapper;

    internal class SolConexionAutogenMapper : Profile
    {
        public SolConexionAutogenMapper()
        {
            CreateMap<Core.CustomEntities.SQLContext.ListadoSolStatusConexionAutogen, ListadoSolStatusConexionAutogenDTO>().ReverseMap();
            CreateMap<Core.CustomEntities.SQLContext.ListadoSolConexionAutogen, ListadoSolConexionAutogenDTO>().ReverseMap();
            CreateMap<Core.Entities.SQLContext.SolConexionAutogen, SolConexionAutogenDTO>().ReverseMap();
            CreateMap<Core.CustomEntities.FormInitialParams.SolConexionAutogenParamsIni, SolConexionAutogenParamsIniDTO>().ReverseMap();
        }
    }
}
