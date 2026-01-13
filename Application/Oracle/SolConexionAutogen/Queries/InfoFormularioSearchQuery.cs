namespace Application.Oracle.SolConexionAutogen.Queries
{
    using Application.Oracle.SolConexionAutogen.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class InfoFormularioSearchQuery : IRequest<InfoFormularioDTO>
    {
        [Required]
        public decimal Empresa { get; set; }

        [Required]
        public string CodTransformador { get; set; }

        //public string Matricula { get; set; }
    }
}
