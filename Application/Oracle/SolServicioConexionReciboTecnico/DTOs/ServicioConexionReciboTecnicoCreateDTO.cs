namespace Application.Oracle.SolServicioConexionReciboTecnico.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class ServicioConexionReciboTecnicoCreateDto
    {
        [Required]
        public int CodSolServicioConexion { get; set; }
        [Required]
        public DateTime FechaSolicitud { get; set; }
        [Required]
        public List<int> CodTiposProyectos { get; set; }
        [Required]
        public int CodTipoSolicitud { get; set; }
        [Required]
        public string NombreProyecto { get; set; }
        [Required]
        public string OficinaRadicacion { get; set; }

        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Comercializador { get; set; }
        [Required]
        public string NumeroMatricula { get; set; }
        [Required]
        public string ClienteCargoCobroMedidores { get; set; }
        [Required]
        public int CodPersonaAutorizacion { get; set; }
        [Required]
        public int CodTipoCompletitud { get; set; }
        public int EtapaProyecto { get; set; }
        [Required]
        public string NombreConstructora { get; set; }
        [Required]
        public string NitConstructora { get; set; }
        [Required]
        public string NombreIngeniero { get; set; }
        public string FirmaIngeniero { get; set; }
        [Required]
        public string MatriculaProfesional { get; set; }
        [Required]
        public string TelefonoIngeniero { get; set; }
        [Required]
        public string EmailIngeniero { get; set; }
        public string NombrePropietario { get; set; }
        [Required]
        public string CedulaPropietario { get; set; }
        [Required]
        public string FirmaPropietario { get; set; }
        [Required]
        public string TelefonoPropietario { get; set; }
        [Required]
        public string EmailPropietario { get; set; }
        [Required]
        public string CedulaIngeniero { get; set; }
        [Required]
        public string Observaciones { get; set; }

    }
}
