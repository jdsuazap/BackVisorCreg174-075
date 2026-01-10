using Core.Entities.Oracle;
using Core.Entities.SQLContext;

namespace Core.CustomEntities.FormInitialParams
{
    public class SolConexionAutogenParamsIni
    {
        public List<TipoGeneracion> ListadoTipoGeneracion { get; set; }
        //public List<ClasificacionProyecto> ListadoClasificacionProyecto { get; set; }
        //public List<Comercializador> ListadoComercializador { get; set; }
        public List<TipoIdentificacion> ListadoTipoIdentificacion { get; set; }
        public List<CregDepartamento> ListadoDepartamento { get; set; }
        public List<CregCiudad> ListadoCiudad { get; set; }
        //public List<TipoCliente> ListadoTipoCliente { get; set; }
        public List<TipoTecnologia> ListadoTipoTecnologia { get; set; }
        public List<TipoAerogenerador> ListadoTipoAerogenerador { get; set; }
        //public List<EstratoSocioeconomico> ListadoEstratoSocioeconomico { get; set; }
        public List<MotivoProrroga> ListadoMotivoProrroga { get; set; }
        //public List<TipoTramiteVisita> ListadoTipoTramiteVisita { get; set; }
        public List<DocumentosXformulario> ListadoDocumentosXformularios { get; set; }
    }
}
