namespace Application.SQLContext.DocumentosXformulario.Queries
{
    using Application.SQLContext.DocumentosXformulario.DTOs;
    using MediatR;

    public record DocumentosXformularioSearchAllQuery() : IRequest<List<DocumentosXformularioDTO>>;
}
