namespace Application.Oracle.SolServicioConexion.Queries
{
    using Application.Oracle.SolServicioConexion.DTOs;
    using MediatR;

    public record SolServicioConexionParametrosInicialesQuery() : IRequest<SolServicioConexionParamsIniDTO>;
}
