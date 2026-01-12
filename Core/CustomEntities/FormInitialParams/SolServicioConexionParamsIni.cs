namespace Core.CustomEntities.FormInitialParams
{
    using Core.Entities.Oracle;

    public class SolServicioConexionParamsIni
    {
        public List<CregTipoPersona> ListadoTipoPersona { get; set; }
        public List<CregTipoIdentificacion> ListadoTipoIdentificacion { get; set; }
        public List<CregTipoZona> ListadoTipoZona { get; set; }
        public List<CregTipoCliente> ListadoTipoCliente { get; set; }
        public List<CregEstratoSocioeconomico> ListadoEstratoSocioeconomico { get; set; }        
        public List<CregTipoSolicitudServicio> ListadoTipoSolicitudServicio { get; set; }
        public List<CregTipoServicio> ListadoTipoServicio { get; set; }
        public List<CregTipoTension> ListadoTipoTension { get; set; }
        public List<CregTipoConexion> ListadoTipoConexion { get; set; }
        public List<CregTipoConstruccion> ListadoTipoConstruccion { get; set; }
        public List<CregTipoSolicitudRecibo> ListadoTipoSolicitudRecibo { get; set; }
        public List<CregTipoProyecto> ListadoTipoProyecto { get; set; }        
        public List<CregTipoCompletitud> ListadoTipoCompletitud { get; set; }
        public List<CregTipoClaseCarga> ListadoTipoClaseCarga { get; set; }        
        public List<CregComercializador> ListadoComercializador { get; set; }
        public List<CregActividadEconomica> ListadoActividadEconomica { get; set; }
        public List<CregDocumentosFormulario> ListadoDocumentosXformularios { get; set; }
        public List<CregPersonaAutoriza> ListadoPersonaAutorizaRecibo { get; set; }
    }
}
