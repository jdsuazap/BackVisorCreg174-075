namespace Application.Oracle.SolServicioConexion.Mapping
{
    using Application.Oracle.SolServicioConexion.DTOs;
    using AutoMapper;
    using Core.CustomEntities.FormInitialParams;
    using Core.Entities.Oracle;

    internal class SolServicioConexionMapper : Profile
    {
        public SolServicioConexionMapper()
        {
            //CreateMap<ListadoSolStatusServicioConexion, ListadoSolStatusServicioConexionDTO>().ReverseMap();
            //CreateMap<ListadoSolServicioConexion, ListadoSolServicioConexionDTO>().ReverseMap();
            CreateMap<Creg075ServicioConexion, SolServicioConexionDTO>().ReverseMap();
            CreateMap<SolServicioConexionParamsIni, SolServicioConexionParamsIniDTO>().ReverseMap();
        }
    }
}
