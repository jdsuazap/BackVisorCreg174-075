namespace Application.SQLContext.SolServicioConexion.Queries
{
    using Application.SQLContext.SolServicioConexion.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolServicioConexionSearchByIdQuery : IRequest<SolServicioConexionDTO>
    {
        [Required]
        public int Id { get; set; }
    }
}
