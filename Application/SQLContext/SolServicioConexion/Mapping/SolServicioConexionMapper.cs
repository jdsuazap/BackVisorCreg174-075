namespace Application.SQLContext.SolServicioConexion.Mapping
{
    using Application.SQLContext.SolServicioConexion.DTOs;
    using AutoMapper;
    using Core.CustomEntities.SQLContext;
    using Core.Entities.SQLContext;

    internal class SolServicioConexionMapper : Profile
    {
        public SolServicioConexionMapper()
        {
            CreateMap<ListadoSolStatusServicioConexion, ListadoSolStatusServicioConexionDTO>().ReverseMap();
            CreateMap<ListadoSolServicioConexion, ListadoSolServicioConexionDTO>().ReverseMap();
            CreateMap<SolServicioConexion, SolServicioConexionDTO>().ReverseMap();
            CreateMap<Core.CustomEntities.FormInitialParams.SolServicioConexionParamsIni, SolServicioConexionParamsIniDTO>().ReverseMap();
        }
    }
}
