namespace Application.SQLContext.SolServicioConexionFactibilidad.Mapping
{
    using Application.SQLContext.SolServicioConexionFactibilidad.DTOs;
    using AutoMapper;

    public class SolServicioConexionFactibilidadMapper : Profile
    {
        public SolServicioConexionFactibilidadMapper()
        {
            CreateMap<Core.Entities.SQLContext.SolServicioConexionFactibilidad, SolServicioConexionFactibilidadDTO>().ReverseMap();            
        }
    }
}
