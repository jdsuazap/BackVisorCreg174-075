namespace Core.CustomEntities.FormInitialParams
{
    using Core.Entities.Oracle;

    public class SolConexionAutogenParamsIni
    {
        public List<CregTipoGeneracion> ListadoTipoGeneracion { get; set; }
        public List<CregClasificacionProyecto> ListadoClasificacionProyecto { get; set; }
        public List<CregComercializador> ListadoComercializador { get; set; }
        public List<CregTipoIdentificacion> ListadoTipoIdentificacion { get; set; }
        public List<CregDepartamento> ListadoDepartamento { get; set; }
        public List<CregCiudad> ListadoCiudad { get; set; }
        public List<CregTipoCliente> ListadoTipoCliente { get; set; }
        public List<CregTipoTecnologia> ListadoTipoTecnologia { get; set; }
        public List<CregTipoAerogenerador> ListadoTipoAerogenerador { get; set; }
        public List<CregEstratoSocioeconomico> ListadoEstratoSocioeconomico { get; set; }
        public List<CregTipoTramiteVisita> ListadoTipoTramiteVisita { get; set; }
        public List<CregDocumentosFormulario> ListadoDocumentosXformularios { get; set; }
    }
}
