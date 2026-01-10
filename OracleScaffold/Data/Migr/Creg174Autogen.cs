using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg174Autogen
    {
        public int Id { get; set; }
        public int? CodTipProcedConexion { get; set; }
        public int? CodEmpresa { get; set; }
        public bool? OrInstalaActivos { get; set; }
        public string NumeroRadicado { get; set; }
        public int CodTipGeneracion { get; set; }
        public bool? EntregaExcedentes { get; set; }
        public DateTime FechaPrevistaOper { get; set; }
        public int? CodClasificacionProyecto { get; set; }
        public int? CodComercializador { get; set; }
        public string NombreOtroComercializador { get; set; }
        public string CodCuentaCliente { get; set; }
        public int? Codigosic { get; set; }
        public string NombreCliente { get; set; }
        public int CodTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string Direccion { get; set; }
        public string CodDepartamentoCliente { get; set; }
        public string CodMunicipioCliente { get; set; }
        public string BarrioCliente { get; set; }
        public int TelefonoCliente { get; set; }
        public string EmailCliente { get; set; }
        public int CodTipoCliente { get; set; }
        public string OtroTipoCliente { get; set; }
        public int? CodEstratoCliente { get; set; }
        public decimal CapacidadNominal { get; set; }
        public decimal PotenciaMaximaDeclarada { get; set; }
        public decimal NivelTension { get; set; }
        public string CodTransformador { get; set; }
        public string CodSubestacion { get; set; }
        public bool? ProtantiIsla { get; set; }
        public string ProtantiIslaDesc { get; set; }
        public bool ClienteSuministraMedidor { get; set; }
        public bool MedidorPerfilHorario { get; set; }
        public bool MedidorBidireccional { get; set; }
        public bool? Eseditable { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaConformidad { get; set; }
        public int? DiasValidacionProrroga { get; set; }
        public DateTime? FechaLimiteProrroga { get; set; }
        public bool? AptoParaProrroga { get; set; }
        public int? DiasFaltantesProrroga { get; set; }
        public bool? ProrrogaEnProceso { get; set; }
        public int? EstadoAnteriorProrroga { get; set; }
        public int? UltimoEstadoProrroga { get; set; }
        public int? DiasValidacionConexion { get; set; }
        public DateTime? FechaLimiteConexion { get; set; }
        public bool? AptoParaConexion { get; set; }
        public int? DiasFaltantesConexion { get; set; }
        public bool? ContratoConexion { get; set; }
        public bool? ContratoConexionFirmado { get; set; }
        public bool? AprobacionVigencia { get; set; }
        public bool? AptoParaDesistimiento { get; set; }
        public bool? DocumentacionRetieAprobada { get; set; }
        public bool? DocumentacionVisitaEntregada { get; set; }
        public bool? UltimoHallazgoFuegrave { get; set; }
        public bool? DesconexionVoluntaria { get; set; }
        public bool? SuperaLimiteTransformador { get; set; }
        public bool? AutorizaGastosSuperalimites { get; set; }
        public int CodEstado { get; set; }
        public int? EstadoVisita { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaRegistroUpdate { get; set; }
    }
}
