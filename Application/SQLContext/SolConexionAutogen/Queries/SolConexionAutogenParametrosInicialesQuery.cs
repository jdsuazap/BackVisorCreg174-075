namespace Application.SQLContext.SolConexionAutogen.Queries
{
    using Application.SQLContext.SolConexionAutogen.DTOs;
    using MediatR;

    public record SolConexionAutogenParametrosInicialesQuery() : IRequest<SolConexionAutogenParamsIniDTO>;
}
