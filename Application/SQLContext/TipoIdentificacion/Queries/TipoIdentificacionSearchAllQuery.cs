using Application.SQLContext.TipoIdentificacion.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Application.SQLContext.TipoIdentificacion.Queries
{
    public record TipoIdentificacionSearchAllQuery() : IRequest<List<TipoIdentificacionDTO>>;
}
