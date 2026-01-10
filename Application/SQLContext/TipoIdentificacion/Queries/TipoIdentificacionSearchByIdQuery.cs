using Application.SQLContext.TipoIdentificacion.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.SQLContext.TipoIdentificacion.Queries
{
    public class TipoIdentificacionSearchByIdQuery : IRequest<TipoIdentificacionDTO>
    {
        [Required]
        public int Id { get; set; }

        //public SearchByIdQuery(int id)
        //{
        //    Id = id;
        //}
    }
}
