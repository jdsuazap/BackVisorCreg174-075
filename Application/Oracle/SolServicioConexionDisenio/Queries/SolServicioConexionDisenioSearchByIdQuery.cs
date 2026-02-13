namespace Application.Oracle.SolServicioConexionDisenio.Queries
{
    using Application.Oracle.SolServicioConexionDisenio.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolServicioConexionDisenioSearchByIdQuery : IRequest<SolServicioConexionDisenioDTO>
    {

        [Required]
        public int Id { get; set; }
    }
}
