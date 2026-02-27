namespace Application.Oracle.SolConexionAutogen.DTOs
{
    using Core.Entities.Oracle;

    public class SolConexionAutogenDTO
    {
        public int Id { get; set; }
        public int? CodTipProcedConexion { get; set; }
        public string NumeroRadicado { get; set; }
        public int? CodEmpresa { get; set; }
        public int CodTipGeneracion { get; set; }
        public int? CodClasificacionProyecto { get; set; }

        public bool? OrinstalaActivos { get; set; }
        public bool EntregaExcedentes { get; set; }
        public DateTime FechaPrevistaOper { get; set; }
        public int? CodComercializador { get; set; }
        public string NombreOtroComercializador { get; set; }
        public int? CodCuentaCliente { get; set; }
        public string NombreCliente { get; set; }
        public int CodTipoIdentificacion { get; set; }

        public string NumeroIdentificacion { get; set; }
        public string Direccion { get; set; }
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
        public bool? ProtantiIsla { get; set; }
        public string ProtantiIslaDesc { get; set; }
        public bool ClienteSuministraMedidor { get; set; }
        public bool MedidorPerfilHorario { get; set; }
        public bool MedidorBidireccional { get; set; }
        public string Observaciones { get; set; }
        public int CodEstado { get; set; }
        public DateTime? FechaConformidad { get; set; }
        public DateTime? FechaLimiteProrroga { get; set; }
        public DateTime? FechaLimiteConexion { get; set; }        
        public DateTime FechaRegistro { get; set; }     
             
        public virtual CregCiudad CregCiudad { get; set; } = null!;
        public virtual CregClasificacionProyecto CregClasificacionProyecto { get; set; }
        public virtual CregComercializador CregComercializador { get; set; }
        public virtual CregDepartamento CregDepartamento { get; set; } = null!;
        public virtual CregEstado CregEstado { get; set; } = null!;
        public virtual CregEstratoSocioeconomico CregEstratoSocioeconomico { get; set; }
        public virtual CregTipoCliente CregTipoCliente { get; set; }
        public virtual CregTipoGeneracion CregTipoGeneracion { get; set; }
        public virtual CregTipoIdentificacion CregTipoIdentificacion { get; set; }
        public virtual Creg174BasInv Creg174BasInv { get; set; }
        public virtual Creg174Infoeolica Creg174Infoeolica { get; set; }
        public virtual Creg174Inmueble Creg174Inmueble { get; set; }
        public virtual Creg174NoBasInv Creg174NoBasInv { get; set; }
        public virtual Creg174Tecnologia Creg174Tecnologia { get; set; }
        public virtual ICollection<Creg174Anexo> Creg174Anexos { get; set; }
        public virtual ICollection<Creg174Pasos> Creg174Historico { get; set; }
        public virtual ICollection<Creg174TecnUtilizada> Creg174TecnUtilizada { get; set; }        
    }
}
