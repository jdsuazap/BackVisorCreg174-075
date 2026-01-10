using System;
using System.Collections.Generic;

namespace Core.Entities.Oracle
{
    public partial class Creg174Autogen
    {
        public Creg174Autogen()
        {
            Creg174Anexos = new HashSet<Creg174Anexo>();
            Creg174BasInvs = new HashSet<Creg174BasInv>();
            Creg174Inmuebles = new HashSet<Creg174Inmueble>();
            Creg174NoBasInvs = new HashSet<Creg174NoBasInv>();
            Creg174TecnUtilizada = new HashSet<Creg174TecnUtilizada>();
            Creg174Tecnologia = new HashSet<Creg174Tecnologia>();
        }

        public int Id { get; set; }
        public int? CodTipProcedConexion { get; set; }
        public int? CodEmpresa { get; set; }
        public bool? OrInstalaActivos { get; set; }
        public string NumeroRadicado { get; set; } = null!;
        public int CodTipGeneracion { get; set; }
        public bool? EntregaExcedentes { get; set; }
        public DateTime FechaPrevistaOper { get; set; }
        public int? CodClasificacionProyecto { get; set; }
        public int? CodComercializador { get; set; }
        public string? NombreOtroComercializador { get; set; }
        public string? CodCuentaCliente { get; set; }
        public int? Codigosic { get; set; }
        public string NombreCliente { get; set; } = null!;
        public int CodTipoIdentificacion { get; set; }
        public string NumeroIdentificacion { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string CodDepartamentoCliente { get; set; } = null!;
        public string CodMunicipioCliente { get; set; } = null!;
        public string? BarrioCliente { get; set; }
        public int TelefonoCliente { get; set; }
        public string EmailCliente { get; set; } = null!;
        public int CodTipoCliente { get; set; }
        public string? OtroTipoCliente { get; set; }
        public int? CodEstratoCliente { get; set; }
        public decimal CapacidadNominal { get; set; }
        public decimal PotenciaMaximaDeclarada { get; set; }
        public decimal NivelTension { get; set; }
        public string? CodTransformador { get; set; }
        public string? CodSubestacion { get; set; }
        public bool? ProtantiIsla { get; set; }
        public string? ProtantiIslaDesc { get; set; }
        public bool ClienteSuministraMedidor { get; set; }
        public bool MedidorPerfilHorario { get; set; }
        public bool MedidorBidireccional { get; set; }
        public bool? Eseditable { get; set; }
        public string? Observaciones { get; set; }
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

        public virtual CregClasificacionProyecto? CodClasificacionProyectoNavigation { get; set; }
        public virtual CregComercializador? CodComercializadorNavigation { get; set; }
        public virtual CregDepartamento CodDepartamentoClienteNavigation { get; set; } = null!;
        public virtual CregEmpresa? CodEmpresaNavigation { get; set; }
        public virtual CregEstado CodEstadoNavigation { get; set; } = null!;
        public virtual CregEstratoSocioeconomico? CodEstratoClienteNavigation { get; set; }
        public virtual CregCiudad CodMunicipioClienteNavigation { get; set; } = null!;
        public virtual CregTipoGeneracion CodTipGeneracionNavigation { get; set; } = null!;
        public virtual CregTipoProcedConexion? CodTipProcedConexionNavigation { get; set; }
        public virtual CregTipoCliente CodTipoClienteNavigation { get; set; } = null!;
        public virtual CregTipoIdentificacion CodTipoIdentificacionNavigation { get; set; } = null!;
        public virtual ICollection<Creg174Anexo> Creg174Anexos { get; set; }
        public virtual ICollection<Creg174BasInv> Creg174BasInvs { get; set; }
        public virtual ICollection<Creg174Inmueble> Creg174Inmuebles { get; set; }
        public virtual ICollection<Creg174NoBasInv> Creg174NoBasInvs { get; set; }
        public virtual ICollection<Creg174TecnUtilizada> Creg174TecnUtilizada { get; set; }
        public virtual ICollection<Creg174Tecnologia> Creg174Tecnologia { get; set; }
    }
}
