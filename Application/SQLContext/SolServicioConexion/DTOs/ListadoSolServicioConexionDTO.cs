namespace Application.SQLContext.SolServicioConexion.DTOs
{
    public class ListadoSolServicioConexionDTO
    {
        public int Estado { get; set; }
        public string NombreEstado { get; set; } = null!;
        public List<SolServicioConexionDTO> Solicitudes { get; set; } = null!;
    }
}
