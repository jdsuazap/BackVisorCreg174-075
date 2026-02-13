namespace Application.Oracle.SolServicioConexionDisenio.DTOs
{
    using Core.CustomEntities.Oracle;

    public class DisenioConAnexosDTO: SolServicioConexionDisenioBase
    {
        public ICollection<DisenioAnexosDTO> SolServicioConexionDisenioAnexo { get; set; }
    }
}
