namespace Application.SQLContext.SolServicioConexionFactibilidad.Queries
{
    using Application.SQLContext.SolServicioConexionFactibilidad.DTOs;
    using MediatR;

    public record SolServicioConexionFactibilidadSearchAllQuery() : IRequest<List<SolServicioConexionFactibilidadDTO>>;
}
