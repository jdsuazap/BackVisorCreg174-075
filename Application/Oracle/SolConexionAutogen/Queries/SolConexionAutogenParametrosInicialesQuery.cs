namespace Application.Oracle.SolConexionAutogen.Queries
{
    using Application.Oracle.SolConexionAutogen.DTOs;
    using MediatR;

    public record SolConexionAutogenParametrosInicialesQuery() : IRequest<SolConexionAutogenParamsIniDTO>;
}
