namespace Application.SQLContext.SolServicioConexionDisenio.Queries
{
    using Application.SQLContext.SolServicioConexionDisenio.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolServicioConexionDisenioSearchByIdQuery : IRequest<SolServicioConexionDisenioDTO>
    {
        [Required]
        public int Id { get; set; }
    }
}
