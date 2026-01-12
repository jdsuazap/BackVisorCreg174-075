namespace Application.Oracle.TipoTecnologia.Queries
{
    using Application.Oracle.TipoTecnologia.DTOs;
    using MediatR;
    using System.Collections.Generic;

    public record TipoTecnologiaSearchAllQuery() : IRequest<List<TipoTecnologiaDTO>>;
}
