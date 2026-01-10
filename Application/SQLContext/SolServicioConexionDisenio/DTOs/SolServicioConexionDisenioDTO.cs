using Core.CustomEntities.SQLContext;

namespace Application.SQLContext.SolServicioConexionDisenio.DTOs
{
    public class SolServicioConexionDisenioDTO
    {
        public long Id { get; set; }
        public ICollection<SolServicioConexionDisenioActorDTO> SolServicioConexionDisenioActores { get; set; }
        public ICollection<SolServicioConexionDisenioPorDocumentoDTO> SolServicioConexionDisenioPorDocumentos { get; set; }
    }
}
