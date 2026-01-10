using Application.SQLContext.SolServicioConexionComentario.DTOs;
namespace Application.SQLContext.SolServicioConexionComentario.Queries
{
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolServicioConexionComentarioSearchByRequestIdQuery : IRequest<List<SolServicioConexionComentarioDTO>>
    {
        [Required]
        public int Id { get; set; }
    }
}
