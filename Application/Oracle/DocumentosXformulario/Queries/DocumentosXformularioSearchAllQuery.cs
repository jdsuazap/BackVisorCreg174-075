namespace Application.Oracle.DocumentosXformulario.Queries
{
    using Application.Oracle.DocumentosXformulario.DTOs;
    using MediatR;

    public record DocumentosXformularioSearchAllQuery() : IRequest<List<DocumentosXformularioDTO>>;
}
