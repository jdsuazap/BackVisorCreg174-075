namespace Application.Oracle.Departamento.Queries
{
    using Application.Oracle.Departamento.DTOs;
    using MediatR;

    public record DepartamentoSearchAllQuery() : IRequest<List<DepartamentoDTO>>;
}
