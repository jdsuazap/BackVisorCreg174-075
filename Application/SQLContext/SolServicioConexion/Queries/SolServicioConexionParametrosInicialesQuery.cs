namespace Application.SQLContext.SolServicioConexion.Queries
{
    using Application.SQLContext.SolServicioConexion.DTOs;
    using MediatR;

    public record SolServicioConexionParametrosInicialesQuery() : IRequest<SolServicioConexionParamsIniDTO>;
}
