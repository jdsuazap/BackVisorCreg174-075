namespace Application.Oracle.SolServicioConexionFactibilidad.DTOs
{
    using Application.Oracle.SolServicioConexion.DTOs;

    public class FactibilidadAnexosDTO : AnexoBaseDTO
    {
        public long CodSolServicioConexionFactibilidad { get; set; } = 0;
        public int CodDocumentosXFormulario { get; set; } = 0;
    }
}
