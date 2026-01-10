namespace Application.Oracle.Ciudad.Mapping
{
    using Application.Oracle.Ciudad.DTOs;
    using AutoMapper;

    internal class CiudadMapper : Profile
    {
        public CiudadMapper()
        {
            CreateMap<Core.Entities.Oracle.CregCiudad, CiudadDTO>().ReverseMap();
        }
    }
}
