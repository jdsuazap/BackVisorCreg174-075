namespace Application.Oracle.SolServicioConexionFactibilidad.DTOs
{
    public class DatosAnexosDTO
    {
        public DatosAnexosDTO()
        {
            DocumentosRequeridosAnexos = new List<DocumentosRequeridosDTO>();
            DocumentosAnexos = new List<DocumentosAnexosDTO>();
        }
        public List<DocumentosRequeridosDTO> DocumentosRequeridosAnexos { get; set; }
        public List<DocumentosAnexosDTO> DocumentosAnexos { get; set; }
    }

    public class DocumentosRequeridosDTO : DocumentosRequeridosBaseDTO
    {
    }

    public class DocumentosAnexosDTO : DocumentosRequeridosBaseDTO
    {
    }

    public class DocumentosRequeridosBaseDTO
    {
        public int IdDocumentoXFormulario { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
    }
}
