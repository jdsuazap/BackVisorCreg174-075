namespace Application.Oracle.ActividadEconomica.Mapping
{
    using Application.Oracle.ActividadEconomica.DTOs;
    using AutoMapper;
    using Core.Entities.Oracle;

    internal class ActividadEconomicaMapper : Profile
    {
        public ActividadEconomicaMapper()
        {
            CreateMap<CregActividadEconomica, ActividadEconomicaDTO>().ReverseMap();
        }
    }
}
