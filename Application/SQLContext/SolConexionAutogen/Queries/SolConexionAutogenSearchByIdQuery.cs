namespace Application.SQLContext.SolConexionAutogen.Queries
{
    using Application.SQLContext.SolConexionAutogen.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class SolConexionAutogenSearchByIdQuery : IRequest<SolConexionAutogenDTO>
    {
        [Required]
        public int Id { get; set; }
    }
}
