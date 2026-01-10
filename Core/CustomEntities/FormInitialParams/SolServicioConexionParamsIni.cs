namespace Core.CustomEntities.FormInitialParams
{
    using Core.Entities.Oracle;
    using Core.Entities.SQLContext;

    public class SolServicioConexionParamsIni
    {
        public List<CregTipoPersona> ListadoTipoPersona { get; set; }
        public List<CregTipoIdentificacion> ListadoTipoIdentificacion { get; set; }
        //public List<TipoZona> ListadoTipoZona { get; set; }
        public List<CregTipoCliente> ListadoTipoCliente { get; set; }
        public List<CregEstratoSocioeconomico> ListadoEstratoSocioeconomico { get; set; }
        //public List<ActividadEconomica> ListadoActividadEconomica { get; set; }
        public List<TipoSolicitudServicio> ListadoTipoSolicitudServicio { get; set; }
        public List<CregTipoServicio> ListadoTipoServicio { get; set; }
        public List<TipoTension> ListadoTipoTension { get; set; }
        public List<CregTipoConexion> ListadoTipoConexion { get; set; }
        public List<CregTipoConstruccion> ListadoTipoConstruccion { get; set; }
        public List<TipoSolicitudRecibo> ListadoTipoSolicitudRecibo { get; set; }
        public List<CregTipoProyecto> ListadoTipoProyecto { get; set; }
        //public List<PersonaAutorizaRecibo> ListadoPersonaAutorizaRecibo { get; set; }
        public List<CregTipoCompletitud> ListadoTipoCompletitud { get; set; }
        public List<CregTipoClaseCarga> ListadoTipoClaseCarga { get; set; }
        //public List<DocumentosXformulario> ListadoDocumentosXformularios { get; set; }
        public List<CregComercializador> ListadoComercializador { get; set; }
    }
}
