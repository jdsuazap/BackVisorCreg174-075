namespace Application.Oracle.Departamento.Mapping
{
    using Application.Oracle.Departamento.DTOs;
    using AutoMapper;

    internal class DepartamentoMapper : Profile
    {
        public DepartamentoMapper()
        {
            CreateMap<Core.Entities.Oracle.CregDepartamento, DepartamentoDTO>().ReverseMap();
        }
    }
}
