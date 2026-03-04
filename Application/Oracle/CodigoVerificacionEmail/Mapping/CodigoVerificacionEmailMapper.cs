namespace Application.Oracle.CodigoVerificacionEmail.Mapping
{
    using Application.Oracle.CodigoVerificacionEmail.DTOs;
    using AutoMapper;
    using Core.CustomEntities.FormInitialParams;
    using Core.Entities.Oracle;

    internal class CodigoVerificacionEmailMapper : Profile
    {
        public CodigoVerificacionEmailMapper()
        {            
            //CreateMap<Creg075ServicioConexion, SolServicioConexionDTO>().ReverseMap();
            //CreateMap<SolServicioConexionParamsIni, SolServicioConexionParamsIniDTO>().ReverseMap();
        }
    }
}
