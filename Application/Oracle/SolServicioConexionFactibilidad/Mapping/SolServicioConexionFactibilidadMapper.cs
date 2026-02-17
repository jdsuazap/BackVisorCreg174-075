namespace Application.Oracle.SolServicioConexionFactibilidad.Mapping
{
    using Application.Oracle.SolServicioConexionFactibilidad.DTOs;
    using AutoMapper;
    using Core.Entities.Oracle;

    public class SolServicioConexionFactibilidadMapper : Profile
    {
        public SolServicioConexionFactibilidadMapper()
        {
            CreateMap<Creg075Factibilidad, SolServicioConexionFactibilidadDTO>().ReverseMap();
            CreateMap<Creg075FactibilidadObs, SolServicioConexionFactibilidadObservacionesDTO>().ReverseMap();
            CreateMap<Creg075FactibilidadDetCuen, SolServicioConexionFactibilidadDetalleCuentasDTO>().ReverseMap();
            CreateMap<Creg075FactibilidadDocu, SolServicioConexionFactibilidadPorDocumentoDTO>().ReverseMap();
            CreateMap<Creg075FactibilidadAnexo, SolServicioConexionFactibilidadAnexosDTO>().ReverseMap();
            CreateMap<Creg075FactibilidadAnexo, FactibilidadAnexosDTO>().ReverseMap();
        }
    }
}
