namespace Application.SQLContext.DocumentosXformulario.Mapping
{
    using Application.SQLContext.DocumentosXformulario.DTOs;
    using AutoMapper;

    internal class DocumentosXformularioMapper : Profile
    {
        public DocumentosXformularioMapper()
        {
            CreateMap<Core.Entities.SQLContext.DocumentosXformulario, DocumentosXformularioDTO>().ReverseMap();
        }
    }
}
