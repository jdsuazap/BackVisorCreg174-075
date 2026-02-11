namespace Application.Oracle.SolServicioConexionFactibilidad.Mapping
{
    using Application.Oracle.SolServicioConexionFactibilidad.DTOs;
    using AutoMapper;

    public class SolServicioConexionFactibilidadMapper : Profile
    {
        public SolServicioConexionFactibilidadMapper()
        {
            CreateMap<Core.Entities.Oracle.Creg075Factibilidad, SolServicioConexionFactibilidadDTO>().ReverseMap();
            //CreateMap<Core.Entities.Oracle.SolServicioConexionFactibilidadObservaciones, SolServicioConexionFactibilidadObservacionesDTO>().ReverseMap();
            //CreateMap<Core.Entities.Oracle.SolServicioConexionFactibilidadDetalleCuentas, SolServicioConexionFactibilidadDetalleCuentasDTO>().ReverseMap();
            //CreateMap<Core.Entities.Oracle.SolServicioConexionFactibilidadPorDocumento, SolServicioConexionFactibilidadPorDocumentoDTO>().ReverseMap();
            CreateMap<Core.Entities.Oracle.Creg075FactibilidadAnexo, SolServicioConexionFactibilidadAnexosDTO>().ReverseMap();
            CreateMap<Core.Entities.Oracle.Creg075FactibilidadAnexo, FactibilidadAnexosDTO>().ReverseMap();
        }
    }
}
