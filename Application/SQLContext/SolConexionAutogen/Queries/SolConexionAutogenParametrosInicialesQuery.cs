using Application.SQLContext.SolConexionAutogen.DTOs;
using MediatR;

namespace Application.SQLContext.SolConexionAutogen.Queries
{
    public record SolConexionAutogenParametrosInicialesQuery() : IRequest<SolConexionAutogenParamsIniDTO>;
}
