namespace Application.SQLContext.SolReciboTecnico.Queries
{
    using Application.SQLContext.SolServicioConexionReciboTecnico.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolServicioConexionReciboTecnicoSearchByIdQuery : IRequest<List<SolServicioConexionReciboTecnicoPorEtapasDTO>>
    {
        [Required]
        public int Id { get; set; }
    }
}
