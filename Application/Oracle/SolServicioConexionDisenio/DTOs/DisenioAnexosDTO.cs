namespace Application.Oracle.SolServicioConexionDisenio.DTOs
{
    using Application.Oracle.SolServicioConexion.DTOs;

    public class DisenioAnexosDTO: AnexoBaseDTO
    {
        public long Id { get; set; }
        public long CodServicioConexionDisenio { get; set; }

        public int CodDocumentosXFormulario { get; set; }
  
    }
}
