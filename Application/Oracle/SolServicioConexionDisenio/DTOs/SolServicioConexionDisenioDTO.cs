namespace Application.Oracle.SolServicioConexionDisenio.DTOs
{
    using Core.CustomEntities.Oracle;

    public class SolServicioConexionDisenioDTO: SolServicioConexionDisenioBase
    {
        public long Id { get; set; }
        public ICollection<SolServicioConexionDisenioActorDTO> SolServicioConexionDisenioActores { get; set; }
        public ICollection<SolServicioConexionDisenioPorDocumentoDTO> SolServicioConexionDisenioPorDocumentos { get; set; }
        public ICollection<DisenioAnexosDTO> SolServicioConexionDisenioAnexo { get; set; }
    }
}
