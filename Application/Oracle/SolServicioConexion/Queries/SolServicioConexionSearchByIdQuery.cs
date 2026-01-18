namespace Application.Oracle.SolServicioConexion.Queries
{
    using Application.Oracle.SolServicioConexion.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolServicioConexionSearchByIdQuery : IRequest<SolServicioConexionDTO>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Empresa { get; set; }
    }
}
