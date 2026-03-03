namespace Application.Oracle.CodigoVerificacionEmail.Commands
{
    using Application.Oracle.CodigoVerificacionEmail.DTOs;
    using MediatR;
    using System.ComponentModel.DataAnnotations;

    public class CrearCodigoVerificacionCommand : IRequest<EnvioCodigoReponse>
    {
        [Required]
        public int  Id { get; set; }

        [Required]
        public int Empresa { get; set; }

        [Required]
        public int TipoSolicitud { get; set; }
    }
}