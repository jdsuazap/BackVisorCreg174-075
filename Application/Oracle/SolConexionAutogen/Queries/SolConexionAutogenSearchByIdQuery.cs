namespace Application.Oracle.SolConexionAutogen.Queries
{
    using Application.Oracle.SolConexionAutogen.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolConexionAutogenSearchByIdQuery : IRequest<SolConexionAutogenDTO>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int Empresa { get; set; }
    }
}
