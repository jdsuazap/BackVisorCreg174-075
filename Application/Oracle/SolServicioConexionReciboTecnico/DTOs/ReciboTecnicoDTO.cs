namespace Application.Oracle.SolServicioConexionReciboTecnico.DTOs
{
    using Application.Oracle.SolReciboTecnico.DTOs;
    using Application.Oracle.SolServicioConexion.DTOs;

    public class ReciboTecnicoDTO
    {
        public long Id { get; set; }
        public int Etapa { get; set; }
        public ReciboTecnicoBaseDTO ReciboTecnicoInfo { get; set; }
        public List<ReciboTecnicoAnexoDTO> ReciboTecnicoAnexos { get; set; }
       
    }

    public class ReciboTecnicoAnexoDTO: AnexoBaseDTO
    {
        public long Id { get; set; }
        public long CodServicioConexionDisenio { get; set; }

        public int CodDocumentosXFormulario { get; set; }

    }
}
