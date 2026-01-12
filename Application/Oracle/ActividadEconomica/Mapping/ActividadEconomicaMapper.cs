namespace Application.Oracle.ActividadEconomica.Mapping
{
    using Application.Oracle.ActividadEconomica.DTOs;
    using AutoMapper;

    internal class ActividadEconomicaMapper : Profile
    {
        public ActividadEconomicaMapper()
        {
            CreateMap<Core.Entities.SQLContext.ActividadEconomica, ActividadEconomicaDTO>().ReverseMap();
        }
    }
}
