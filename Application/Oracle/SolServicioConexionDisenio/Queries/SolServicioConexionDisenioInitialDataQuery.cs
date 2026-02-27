using Application.Oracle.SolServicioConexionDisenio.DTOs;
using MediatR;

namespace Application.Oracle.SolServicioConexionDisenio.Queries
{
    public record SolServicioConexionDisenioInitialDataQuery() : IRequest<DatosAnexosDisenioDTO>;
}
