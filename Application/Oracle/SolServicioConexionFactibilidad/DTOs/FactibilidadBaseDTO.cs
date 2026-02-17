namespace Application.Oracle.SolServicioConexionFactibilidad.DTOs
{
    public class FactibilidadBaseDTO
    {
        public long Id { get; set; }
        public int CodSolServicioConexion { get; set; }
        public long CodSolServicioConexionFactibilidad { get; set; }
        public string NumeroFactibilidad { get; set; }
    }
}
