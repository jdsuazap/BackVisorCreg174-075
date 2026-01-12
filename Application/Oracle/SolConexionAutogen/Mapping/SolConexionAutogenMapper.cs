namespace Application.Oracle.SolConexionAutogen.Mapping
{
    using Application.Oracle.SolConexionAutogen.DTOs;
    using AutoMapper;

    internal class SolConexionAutogenMapper : Profile
    {
        public SolConexionAutogenMapper()
        {
            CreateMap<Core.CustomEntities.Oracle.ListadoSolStatusConexionAutogen, ListadoSolStatusConexionAutogenDTO>().ReverseMap();
            CreateMap<Core.CustomEntities.Oracle.ListadoSolConexionAutogen, ListadoSolConexionAutogenDTO>().ReverseMap();
            CreateMap<Core.Entities.Oracle.Creg174Autogen, SolConexionAutogenDTO>().ReverseMap();
            CreateMap<Core.CustomEntities.FormInitialParams.SolConexionAutogenParamsIni, SolConexionAutogenParamsIniDTO>().ReverseMap();
        }
    }
}
