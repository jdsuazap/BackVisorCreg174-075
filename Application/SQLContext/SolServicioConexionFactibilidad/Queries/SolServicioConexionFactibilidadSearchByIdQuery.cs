namespace Application.SQLContext.SolServicioConexionFactibilidad.Queries
{
    using Application.SQLContext.SolServicioConexionFactibilidad.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolServicioConexionFactibilidadSearchByIdQuery : IRequest<SolServicioConexionFactibilidadDTO>
    {
        [Required]
        public int CodSolServicioConexion { get; set; }
        [Required]
        public int Empresa { get; set; }
    }
}
