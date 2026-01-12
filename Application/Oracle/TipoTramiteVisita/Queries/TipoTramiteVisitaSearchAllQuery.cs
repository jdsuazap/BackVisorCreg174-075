namespace Application.Oracle.TipoTramiteVisita.Queries
{
    using Application.Oracle.TipoTramiteVisita.DTOs;
    using MediatR;
    using System.Collections.Generic;
    public record TipoTramiteVisitaSearchAllQuery() : IRequest<List<TipoTramiteVisitaDTO>>;
}
