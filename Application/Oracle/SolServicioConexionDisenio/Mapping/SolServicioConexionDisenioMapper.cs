namespace Application.SQLContext.SolServicioConexionDisenio.Mapping
{
    using Application.Oracle.SolServicioConexionDisenio.DTOs;
    using AutoMapper;
    using Core.Entities.Oracle;

    public class SolServicioConexionDisenioMapper : Profile
    {
        public SolServicioConexionDisenioMapper()
        {
            CreateMap<Creg075Disenio, SolServicioConexionDisenioDTO>().ReverseMap();
            CreateMap<Creg075DisenioActor, SolServicioConexionDisenioActorDTO>().ReverseMap();
            CreateMap<Creg075DisenioDocu, SolServicioConexionDisenioPorDocumentoDTO>().ReverseMap();
            CreateMap<Core.Entities.Oracle.Creg075DisenioAnexo, DisenioAnexosDTO> ().ReverseMap();
        }
    }
}
