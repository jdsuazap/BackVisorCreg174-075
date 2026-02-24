namespace Application.Oracle.SolServicioConexionFactibilidad.Queries
{
    using Application.Oracle.SolServicioConexionFactibilidad.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolServicioConexionFactibilidadSearchByIdQuery : IRequest<SolServicioConexionFactibilidadDTO>
    {
        [Required]
        public long Id { get; set; }

        [Required]
        public int Numero_Radicado { get; set; }

        [Required]
        public int Empresa { get; set; }
    }
}
