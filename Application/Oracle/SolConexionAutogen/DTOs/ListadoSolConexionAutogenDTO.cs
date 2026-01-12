namespace Application.Oracle.SolConexionAutogen.DTOs
{
    public class ListadoSolConexionAutogenDTO
    {
        public int Estado { get; set; }
        public string NombreEstado { get; set; } = null!;
        public List<SolConexionAutogenDTO> Solicitudes { get; set; } = null!;
    }
}
