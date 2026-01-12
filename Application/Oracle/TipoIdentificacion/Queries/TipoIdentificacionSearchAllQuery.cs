namespace Application.Oracle.TipoIdentificacion.Queries
{
    using Application.Oracle.TipoIdentificacion.DTOs;
    using MediatR;
    using System.Collections.Generic;
    public record TipoIdentificacionSearchAllQuery() : IRequest<List<TipoIdentificacionDTO>>;
}
