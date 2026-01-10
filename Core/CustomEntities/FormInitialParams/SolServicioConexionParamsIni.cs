namespace Core.CustomEntities.FormInitialParams
{
    using Core.Entities.SQLContext;

    public class SolServicioConexionParamsIni
    {
        public List<TipoPersona> ListadoTipoPersona { get; set; }
        public List<TipoIdentificacion> ListadoTipoIdentificacion { get; set; }
        //public List<TipoZona> ListadoTipoZona { get; set; }
        //public List<TipoCliente> ListadoTipoCliente { get; set; }
        //public List<EstratoSocioeconomico> ListadoEstratoSocioeconomico { get; set; }
        //public List<ActividadEconomica> ListadoActividadEconomica { get; set; }
        public List<TipoSolicitudServicio> ListadoTipoSolicitudServicio { get; set; }
        public List<TipoServicio> ListadoTipoServicio { get; set; }
        public List<TipoTension> ListadoTipoTension { get; set; }
        public List<TipoConexion> ListadoTipoConexion { get; set; }
        public List<TipoConstruccion> ListadoTipoConstruccion { get; set; }
        public List<TipoSolicitudRecibo> ListadoTipoSolicitudRecibo { get; set; }
        public List<TipoProyecto> ListadoTipoProyecto { get; set; }
        //public List<PersonaAutorizaRecibo> ListadoPersonaAutorizaRecibo { get; set; }
        public List<TipoCompletitud> ListadoTipoCompletitud { get; set; }
        public List<TipoClaseCarga> ListadoTipoClaseCarga { get; set; }
        public List<DocumentosXformulario> ListadoDocumentosXformularios { get; set; }
        //public List<Comercializador> ListadoComercializador { get; set; }
    }
}
