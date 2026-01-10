namespace Core.Entities.SQLContext
{
    public class SolServicioConexionDisenio : GenericBaseEntity<long>
    {
        public int CodServicioConexion { get; set; }
        public SolServicioConexion SolServicioConexion { get; set; }
        public long CodFactibilidad { get; set; }
        public SolServicioConexionFactibilidad SolServicioConexionFactibilidad { get; set; }
        public int TipoDocumento { get; set; }
        public string NombreProyecto { get; set; }
        public string? NombreConstructora { get; set; }
        public string? Nit { get; set; }
        public bool TieneDocumentacion { get; set; }
        public int Etapa { get; set; }
        public string CedulaObservaciones { get; set; }
        public string NombreObservaciones { get; set; }
    }
}
