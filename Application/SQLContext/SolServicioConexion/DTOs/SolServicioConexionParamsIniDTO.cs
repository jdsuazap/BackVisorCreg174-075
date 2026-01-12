namespace Application.SQLContext.SolServicioConexion.DTOs
{
    using Application.Oracle.TipoIdentificacion.DTOs;
    using Application.Oracle.EstratoSocioeconomico.DTOs;
    using Application.Oracle.TipoZona.DTOs;
    using Application.Oracle.Comercializador.DTOs;
    using Application.Oracle.TipoCliente.DTOs;
    using Application.Oracle.ActividadEconomica.DTOs;
    using Application.Oracle.TipoPersona.DTOs;
    using Application.Oracle.TipoSolicitudRecibo.DTOs;
    using Application.Oracle.TipoSolicitudServicio.DTOs;
    using Application.Oracle.TipoServicio.DTOs;
    using Application.Oracle.TipoTension.DTOs;
    using Application.Oracle.TipoConexion.DTOs;
    using Application.Oracle.TipoConstruccion.DTOs;
    using Application.Oracle.TipoProyecto.DTOs;
    using Application.Oracle.TipoCompletitud.DTOs;
    using Application.Oracle.TipoClaseCarga.DTOs;
    using Application.Oracle.PersonaAutorizaRecibo.DTOs;
    using Application.Oracle.DocumentosXformulario.DTOs;

    public class SolServicioConexionParamsIniDTO
    {
        public List<TipoPersonaDTO> ListadoTipoPersona { get; set; }
        public List<TipoIdentificacionDTO> ListadoTipoIdentificacion { get; set; }
        public List<TipoZonaDTO> ListadoTipoZona { get; set; }
        public List<TipoClienteDTO> ListadoTipoCliente { get; set; }
        public List<EstratoSocioeconomicoDTO> ListadoEstratoSocioeconomico { get; set; }
        public List<ActividadEconomicaDTO> ListadoActividadEconomica { get; set; }
        public List<TipoSolicitudServicioDTO> ListadoTipoSolicitudServicio { get; set; }
        public List<TipoServicioDTO> ListadoTipoServicio { get; set; }
        public List<TipoTensionDTO> ListadoTipoTension { get; set; }
        public List<TipoConexionDTO> ListadoTipoConexion { get; set; }
        public List<TipoConstruccionDTO> ListadoTipoConstruccion { get; set; }
        public List<TipoSolicitudReciboDTO> ListadoTipoSolicitudRecibo { get; set; }
        public List<TipoProyectoDTO> ListadoTipoProyecto { get; set; }
        public List<PersonaAutorizaReciboDTO> ListadoPersonaAutorizaRecibo { get; set; }
        public List<TipoCompletitudDTO> ListadoTipoCompletitud { get; set; }
        public List<TipoClaseCargaDTO> ListadoTipoClaseCarga { get; set; }
        public List<DocumentosXformularioDTO> ListadoDocumentosXformularios { get; set; }
        public List<ComercializadorDTO> ListadoComercializador { get; set; }
    }
}
