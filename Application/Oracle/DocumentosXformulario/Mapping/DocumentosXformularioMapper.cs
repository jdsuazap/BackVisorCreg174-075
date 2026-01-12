namespace Application.Oracle.DocumentosXformulario.Mapping
{
    using Application.Oracle.DocumentosXformulario.DTOs;
    using AutoMapper;

    internal class DocumentosXformularioMapper : Profile
    {
        public DocumentosXformularioMapper()
        {
            CreateMap<Core.Entities.Oracle.CregDocumentosFormulario, DocumentosXformularioDTO>().ReverseMap();
        }
    }
}
