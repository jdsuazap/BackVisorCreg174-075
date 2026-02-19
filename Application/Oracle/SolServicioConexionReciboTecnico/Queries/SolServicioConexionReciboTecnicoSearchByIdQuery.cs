namespace Application.Oracle.SolReciboTecnico.Queries
{
    using Application.Oracle.SolServicioConexionReciboTecnico.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolServicioConexionReciboTecnicoSearchByIdQuery : IRequest<List<SolServicioConexionReciboTecnicoPorEtapasDTO>>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Numero_Radicado { get; set; }

        [Required]
        public int Empresa { get; set; }
    }
}
