namespace Application.Oracle.SolServicioConexionDisenio.DTOs
{
    using Core.CustomEntities.Oracle;
    using Core.Entities.Oracle;

    public class SolServicioConexionDisenioDTO: SolServicioConexionDisenioBase
    {
        public long Id { get; set; }
        public ICollection<SolServicioConexionDisenioActorDTO> Creg075DisenioActor { get; set; }
        public ICollection<SolServicioConexionDisenioPorDocumentoDTO> Creg075DisenioDocu { get; set; }
        public ICollection<DisenioAnexosDTO> Creg075DisenioAnexo { get; set; }
    }
}
