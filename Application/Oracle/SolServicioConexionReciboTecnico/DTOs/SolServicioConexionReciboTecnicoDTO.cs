namespace Application.Oracle.SolReciboTecnico.DTOs
{
    using Application.Oracle.SolServicioConexionReciboTecnico.DTOs;
    public class ReciboTecnicoBaseDTO
    {
        public int Cod075Conexion { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int CodTipoSolicitud { get; set; }
        public List<int> CodTiposProyectos { get; set; }
        public string OficinaRadicacion { get; set; }
        public string NumeroSolServicioConexion { get; set; }
        public string NumeroFactibilidad { get; set; }
        public string NombreProyecto { get; set; }
        public string Direccion { get; set; }
        public string Comercializador { get; set; }
        public string NumeroMatricula { get; set; }
        public string ClienteCargoMedidor { get; set; }
        public int CodPersonaAutorizacion { get; set; }
        public int CodTipoCompletitud { get; set; }
        public int EtapaProyecto { get; set; }
        public string NombreConstructora { get; set; }
        public string NitConstructora { get; set; }
        public string NombreIngeniero { get; set; }
        public string FirmaIngeniero { get; set; }
        public string MatriculaProfesional { get; set; }
        public string TelefonoIngeniero { get; set; }
        public string EmailIngeniero { get; set; }
        public string CedulaIngeniero { get; set; }
        public string NombrePropietario { get; set; }
        public string FirmaPropietario { get; set; }
        public string TelefonoPropietario { get; set; }
        public string EmailPropietario { get; set; }
        public string CedulaPropietario { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
    public class SolServicioConexionReciboTecnicoDTO: ReciboTecnicoBaseDTO
    {
        public long Id { get; set; }
        public List<ReciboTecnicoAnexoDTO> ReciboTecnicoAnexos { get; set; }

    }
}
