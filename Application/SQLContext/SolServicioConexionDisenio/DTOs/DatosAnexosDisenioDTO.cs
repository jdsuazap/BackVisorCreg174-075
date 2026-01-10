namespace Application.SQLContext.SolServicioConexionDisenio.DTOs
{
    public class DatosAnexosDisenioDTO
    {
        public DatosAnexosDisenioDTO()
        {
            DocumentosRequeridosAnexos = new List<DocumentosRequeridosDisenioDTO>();
            DocumentosAnexos = new List<DocumentosAnexosDisenioDTO>();
            DocumentosQuePresenta = new List<DocumentosPresentaDisenioDTO>();
        }
        public List<DocumentosRequeridosDisenioDTO> DocumentosRequeridosAnexos { get; set; }
        public List<DocumentosAnexosDisenioDTO> DocumentosAnexos { get; set; }
        public List<DocumentosPresentaDisenioDTO> DocumentosQuePresenta { get; set; }
    }

    public class DocumentosRequeridosDisenioDTO: DocumentosAnexosDisenioBaseDTO
    {
    }

    public class DocumentosAnexosDisenioDTO: DocumentosAnexosDisenioBaseDTO
    {
    }

    public class DocumentosPresentaDisenioDTO : DocumentosAnexosDisenioBaseDTO
    {
    }

    public class DocumentosAnexosDisenioBaseDTO
    {
        public int IdDocumentoXFormulario { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public bool   Requiered { get; set; }
    }
}
