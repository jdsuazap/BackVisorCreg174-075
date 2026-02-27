namespace Application.Oracle.SolServicioConexionFactibilidad.Queries
{
    using Application.Oracle.SolServicioConexionFactibilidad.DTOs;
    using MediatR;

    public record SolServicioConexionFactibilidadInitialDataQuery() : IRequest<DatosAnexosDTO>;
}
