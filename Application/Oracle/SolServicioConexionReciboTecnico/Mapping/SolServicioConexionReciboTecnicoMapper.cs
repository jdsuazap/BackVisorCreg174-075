namespace Application.Oracle.SolReciboTecnico.Mapping
{
    using Application.Oracle.SolReciboTecnico.DTOs;
    using Application.Oracle.SolServicioConexionReciboTecnico.DTOs;
    using AutoMapper;
    using Core.Entities.Oracle;

    internal class SolServicioConexionReciboTecnicoMapper : Profile
    {
        public SolServicioConexionReciboTecnicoMapper()
        {
            CreateMap<Creg075ReciboTecnico, SolServicioConexionReciboTecnicoDTO>().ReverseMap();
            CreateMap<Creg075ReciboTecnicoAnexo, ReciboTecnicoAnexoDTO>().ReverseMap();
            CreateMap<Creg075ReciboTecnico, ReciboTecnicoBaseDTO>().ReverseMap();
        }
    }
}
