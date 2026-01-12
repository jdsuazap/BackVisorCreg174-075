namespace Application.Oracle.SolConexionAutogen.DTOs
{
    using Application.SQLContext.SolConexionAutogenComentario.DTOs;

    public class SolConexionAutogenDTO
    {
        public int Id { get; set; }
        public int CodUsuario { get; set; }
        public int? CodTipoProcedimientoConexion { get; set; }
        public string NumeroRadicado { get; set; }
        public int? Empresa { get; set; }
        public bool? OrinstalaActivos { get; set; }
        public int CodTipoGeneracion { get; set; }
        public bool EntregaExcedentes { get; set; }
        public DateTime FechaPrevistaOper { get; set; }
        public int? CodClasificacionProyecto { get; set; }
        public int? CodComercializador { get; set; }
        public string NombreOtroComercializador { get; set; }
        public int? CodCuentaCliente { get; set; }
        public int? CodigoSic { get; set; }
        public string NombreCliente { get; set; }
        public int CodTipoIdentificacionCliente { get; set; }
        public string NumeroIdentificacionCliente { get; set; }
        public string DireccionCliente { get; set; }
        public string CodDepartamentoCliente { get; set; }
        public string CodMunicipioCliente { get; set; }
        public string BarrioCliente { get; set; }
        public decimal TelefonoCliente { get; set; }
        public string EmailCliente { get; set; }
        public int CodTipoCliente { get; set; }
        public string OtroTipoCliente { get; set; }
        public int? CodEstratoCliente { get; set; }
        public decimal CapacidadNominal { get; set; }
        public decimal PotenciaMaximaDeclarada { get; set; }
        public decimal NivelTension { get; set; }
        public string CodTransformador { get; set; }
        public string CodSubestacion { get; set; }
        public bool? ProtAntiIslaFuncionProteccion { get; set; }
        public string ProtAntiIslaDescFuncionAntiIsla { get; set; }
        public bool ClienteSuministraMedidor { get; set; }
        public bool MedidorPerfilHorario { get; set; }
        public bool MedidorBidireccional { get; set; }
        public bool EsEditable { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaConformidad { get; set; }
        public int? DiasValidacionProrroga { get; set; }
        public DateTime? FechaLimiteProrroga { get; set; }
        public bool? AptoParaProrroga { get; set; }
        public int? DiasFaltantesProrroga { get; set; }
        public int? DiasValidacionConexion { get; set; }
        public DateTime? FechaLimiteConexion { get; set; }
        public bool? AptoParaConexion { get; set; }
        public int? DiasFaltantesConexion { get; set; }
        public bool? ContratoConexion { get; set; }
        public bool? ContratoConexionFirmado { get; set; }
        public bool AprobacionVigencia { get; set; }
        public bool AptoParaDesistimiento { get; set; }
        public bool ProrrogaEnProceso { get; set; }
        public bool? DocumentacionRetieAprobada { get; set; }
        public bool DocumentacionVisitaEntregada { get; set; }
        public bool? UltimoHallazgoFueGrave { get; set; }
        public bool? DesconexionVoluntaria { get; set; }
        public int Estado { get; set; }
        public int? EstadoVisita { get; set; }
        public int? EstadoAnteriorProrroga { get; set; }
        public int? UltimoEstadoProrroga { get; set; }
        public bool? SuperaLimiteTransformador { get; set; }        
        public bool? AutorizaGastosSuperaLimites { get; set; }
        public DateTime FechaRegistro { get; set; }
        public long? AlertId { get; set; }
        public bool? RequiereRETIE { get; set; }
        public string? MsgRequiereRETIE { get; set; }
        public bool? RequiereContrato { get; set; }
        public string? MsgRequiereContrato { get; set; }
        public bool ExcedeVisitaConexionRechazo { get; set; }
             
        public virtual ICollection<SolConexionAutogenComentarioDTO> SolConexionAutogenComentarios { get; set; }        
    }
}
