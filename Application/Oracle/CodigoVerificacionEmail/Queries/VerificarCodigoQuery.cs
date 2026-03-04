namespace Application.Oracle.Pasarela.Queries
{
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class VerificarCodigoQuery : IRequest<bool>
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Codigo { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
