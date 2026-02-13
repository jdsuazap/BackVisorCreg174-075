namespace Application.SQLContext.SolServicioConexionDisenio.Mapping
{
    using Application.Oracle.SolServicioConexionDisenio.DTOs;
    using AutoMapper;
    public class SolServicioConexionDisenioMapper : Profile
    {
        public SolServicioConexionDisenioMapper()
        {
            CreateMap<Core.Entities.Oracle.Creg075Disenio, SolServicioConexionDisenioDTO>().ReverseMap();
            CreateMap<Core.Entities.Oracle.Creg075DisenioActor, SolServicioConexionDisenioActorDTO>().ReverseMap();
            CreateMap<Core.Entities.Oracle.Creg075DisenioDocu, SolServicioConexionDisenioPorDocumentoDTO>().ReverseMap();
            CreateMap<Core.Entities.Oracle.Creg075DisenioAnexo, DisenioAnexosDTO> ().ReverseMap();
        }
    }
}
