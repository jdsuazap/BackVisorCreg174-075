namespace Core.CustomEntities.Oracle
{
    using Core.Enumerations;

    public class SolServicioConexionDisenioBase
    {
        public int CodServicioConexion { get; set; }
        public int TipoDocumento { get; set; }
        public string NombreProyecto { get; set; }
        public string? NombreConstructora { get; set; }
        public string? Nit { get; set; }
        public bool TieneDocumentacion { get; set; }
        public int Etapa { get; set; }
        public string CedulaObservaciones { get; set; }
        public string NombreObservaciones { get; set; }

    }

    public class SolServicioConexionDisenioCreate: SolServicioConexionDisenioBase
    {
        public ICollection<SolServicioConexionDisenioActorCreate> SolServicioConexionDisenioActores { get; set; }
        public ICollection<SolServicioConexionDisenioPorDocumentoCreate> SolServicioConexionDisenioPorDocumentos { get; set; }
    }   
    
    public class SolServicioConexionDisenioActorCreate
    {
        public string Nombre { get; set; }
        public string Firma { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public TipoActorDisenioEnum TipoActor { get; set; }
    }

    public class SolServicioConexionDisenioPorDocumentoCreate
    {
        public int CodServicioConexion { get; set; }

        public int CodDocumentosXFormulario { get; set; }

        public bool Valor { get; set; }
    }
}
