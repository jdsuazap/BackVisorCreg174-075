using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Entities.Oracle
{
    public partial class PruebaCtx : DbContext
    {
        public PruebaCtx()
        {
        }

        public PruebaCtx(DbContextOptions<PruebaCtx> options)
            : base(options)
        {
        }

        public virtual DbSet<Creg174Autogen> Creg174Autogens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("VISOR");

            modelBuilder.Entity<Creg174Autogen>(entity =>
            {
                entity.ToTable("CREG_174_AUTOGEN");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AprobacionVigencia)
                    .HasPrecision(1)
                    .HasColumnName("APROBACION_VIGENCIA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AptoParaConexion)
                    .HasPrecision(1)
                    .HasColumnName("APTO_PARA_CONEXION")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.AptoParaDesistimiento)
                    .HasPrecision(1)
                    .HasColumnName("APTO_PARA_DESISTIMIENTO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.AptoParaProrroga)
                    .HasPrecision(1)
                    .HasColumnName("APTO_PARA_PRORROGA")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.AutorizaGastosSuperalimites)
                    .HasPrecision(1)
                    .HasColumnName("AUTORIZA_GASTOS_SUPERALIMITES")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.BarrioCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BARRIO_CLIENTE");

                entity.Property(e => e.CapacidadNominal)
                    .HasColumnType("NUMBER(10,4)")
                    .HasColumnName("CAPACIDAD_NOMINAL");

                entity.Property(e => e.ClienteSuministraMedidor)
                    .HasPrecision(1)
                    .HasColumnName("CLIENTE_SUMINISTRA_MEDIDOR");

                entity.Property(e => e.CodClasificacionProyecto)
                    .HasPrecision(10)
                    .HasColumnName("COD_CLASIFICACION_PROYECTO");

                entity.Property(e => e.CodComercializador)
                    .HasPrecision(10)
                    .HasColumnName("COD_COMERCIALIZADOR");

                entity.Property(e => e.CodCuentaCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("COD_CUENTA_CLIENTE");

                entity.Property(e => e.CodDepartamentoCliente)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COD_DEPARTAMENTO_CLIENTE");

                entity.Property(e => e.CodEmpresa)
                    .HasPrecision(10)
                    .HasColumnName("COD_EMPRESA");

                entity.Property(e => e.CodEstado)
                    .HasPrecision(10)
                    .HasColumnName("COD_ESTADO");

                entity.Property(e => e.CodEstratoCliente)
                    .HasPrecision(10)
                    .HasColumnName("COD_ESTRATO_CLIENTE");

                entity.Property(e => e.CodMunicipioCliente)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("COD_MUNICIPIO_CLIENTE");

                entity.Property(e => e.CodSubestacion)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("COD_SUBESTACION");

                entity.Property(e => e.CodTipGeneracion)
                    .HasPrecision(10)
                    .HasColumnName("COD_TIP_GENERACION");

                entity.Property(e => e.CodTipProcedConexion)
                    .HasPrecision(10)
                    .HasColumnName("COD_TIP_PROCED_CONEXION");

                entity.Property(e => e.CodTipoCliente)
                    .HasPrecision(10)
                    .HasColumnName("COD_TIPO_CLIENTE");

                entity.Property(e => e.CodTipoIdentificacion)
                    .HasPrecision(10)
                    .HasColumnName("COD_TIPO_IDENTIFICACION");

                entity.Property(e => e.CodTransformador)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("COD_TRANSFORMADOR");

                entity.Property(e => e.Codigosic)
                    .HasPrecision(10)
                    .HasColumnName("CODIGOSIC");

                entity.Property(e => e.ContratoConexion)
                    .HasPrecision(1)
                    .HasColumnName("CONTRATO_CONEXION")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ContratoConexionFirmado)
                    .HasPrecision(1)
                    .HasColumnName("CONTRATO_CONEXION_FIRMADO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DesconexionVoluntaria)
                    .HasPrecision(1)
                    .HasColumnName("DESCONEXION_VOLUNTARIA")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.DiasFaltantesConexion)
                    .HasPrecision(10)
                    .HasColumnName("DIAS_FALTANTES_CONEXION")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.DiasFaltantesProrroga)
                    .HasPrecision(10)
                    .HasColumnName("DIAS_FALTANTES_PRORROGA")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.DiasValidacionConexion)
                    .HasPrecision(10)
                    .HasColumnName("DIAS_VALIDACION_CONEXION")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.DiasValidacionProrroga)
                    .HasPrecision(10)
                    .HasColumnName("DIAS_VALIDACION_PRORROGA")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.DocumentacionRetieAprobada)
                    .HasPrecision(1)
                    .HasColumnName("DOCUMENTACION_RETIE_APROBADA")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.DocumentacionVisitaEntregada)
                    .HasPrecision(1)
                    .HasColumnName("DOCUMENTACION_VISITA_ENTREGADA")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EmailCliente)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_CLIENTE");

                entity.Property(e => e.EntregaExcedentes)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("ENTREGA_EXCEDENTES")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Eseditable)
                    .HasPrecision(1)
                    .HasColumnName("ESEDITABLE")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.EstadoAnteriorProrroga)
                    .HasPrecision(10)
                    .HasColumnName("ESTADO_ANTERIOR_PRORROGA")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.EstadoVisita)
                    .HasPrecision(10)
                    .HasColumnName("ESTADO_VISITA")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.FechaConformidad)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_CONFORMIDAD")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.FechaLimiteConexion)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_LIMITE_CONEXION")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.FechaLimiteProrroga)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_LIMITE_PRORROGA")
                    .HasDefaultValueSql("NULL ");

                entity.Property(e => e.FechaPrevistaOper)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_PREVISTA_OPER");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_REGISTRO")
                    .HasDefaultValueSql("SYSDATE");

                entity.Property(e => e.FechaRegistroUpdate)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHA_REGISTRO_UPDATE")
                    .HasDefaultValueSql("SYSDATE\n   ");

                entity.Property(e => e.MedidorBidireccional)
                    .HasPrecision(1)
                    .HasColumnName("MEDIDOR_BIDIRECCIONAL");

                entity.Property(e => e.MedidorPerfilHorario)
                    .HasPrecision(1)
                    .HasColumnName("MEDIDOR_PERFIL_HORARIO");

                entity.Property(e => e.NivelTension)
                    .HasColumnType("NUMBER(10,4)")
                    .HasColumnName("NIVEL_TENSION");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_CLIENTE");

                entity.Property(e => e.NombreOtroComercializador)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE_OTRO_COMERCIALIZADOR");

                entity.Property(e => e.NumeroIdentificacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO_IDENTIFICACION");

                entity.Property(e => e.NumeroRadicado)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMERO_RADICADO");

                entity.Property(e => e.Observaciones)
                    .IsUnicode(false)
                    .HasColumnName("OBSERVACIONES");

                entity.Property(e => e.OrInstalaActivos)
                    .HasPrecision(1)
                    .HasColumnName("OR_INSTALA_ACTIVOS");

                entity.Property(e => e.OtroTipoCliente)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OTRO_TIPO_CLIENTE");

                entity.Property(e => e.PotenciaMaximaDeclarada)
                    .HasColumnType("NUMBER(10,4)")
                    .HasColumnName("POTENCIA_MAXIMA_DECLARADA");

                entity.Property(e => e.ProrrogaEnProceso)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("PRORROGA_EN_PROCESO")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProtantiIsla)
                    .HasPrecision(1)
                    .HasColumnName("PROTANTI_ISLA");

                entity.Property(e => e.ProtantiIslaDesc)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("PROTANTI_ISLA_DESC");

                entity.Property(e => e.SuperaLimiteTransformador)
                    .HasPrecision(1)
                    .HasColumnName("SUPERA_LIMITE_TRANSFORMADOR")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.TelefonoCliente)
                    .HasPrecision(10)
                    .HasColumnName("TELEFONO_CLIENTE");

                entity.Property(e => e.UltimoEstadoProrroga)
                    .HasPrecision(10)
                    .HasColumnName("ULTIMO_ESTADO_PRORROGA")
                    .HasDefaultValueSql("0 ");

                entity.Property(e => e.UltimoHallazgoFuegrave)
                    .HasPrecision(1)
                    .HasColumnName("ULTIMO_HALLAZGO_FUEGRAVE")
                    .HasDefaultValueSql("0 ");
            });

            modelBuilder.HasSequence("SEQ_CREG_AUTOGEN_EOLICA");

            modelBuilder.HasSequence("SEQ_CREG_AUTOGEN_INM");

            modelBuilder.HasSequence("SEQ_CREG_AUTOGEN_NO_BAS_INV");

            modelBuilder.HasSequence("SEQ_CREG_AUTOGEN_TEC");

            modelBuilder.HasSequence("SEQ_CREG_AUTOGEN_TEC_UTIL");

            modelBuilder.HasSequence("SEQ_CREG_CLAS_PROY");

            modelBuilder.HasSequence("SEQ_CREG_COMERCIALIZADOR");

            modelBuilder.HasSequence("SEQ_CREG_CON_AUTOGEN_BASINV");

            modelBuilder.HasSequence("SEQ_CREG_CON_AUTOGEN_INM");

            modelBuilder.HasSequence("SEQ_CREG_CON_AUTOGEN_NOBASINV");

            modelBuilder.HasSequence("SEQ_CREG_CON_AUTOGEN_TEC");

            modelBuilder.HasSequence("SEQ_CREG_CON_AUTOGEN_TEC_UTIL");

            modelBuilder.HasSequence("SEQ_CREG_CON_AUTOGEN_TECUTIL");

            modelBuilder.HasSequence("SEQ_CREG_EMPRESAS");

            modelBuilder.HasSequence("SEQ_CREG_ETAPAS");

            modelBuilder.HasSequence("SEQ_CREG_PASOSSOL075");

            modelBuilder.HasSequence("SEQ_CREG_PASOSSOL174");

            modelBuilder.HasSequence("SEQ_CREG_SOL_CONEXION_NANEXOS");

            modelBuilder.HasSequence("SEQ_CREG_TIPO_CLIENTE");

            modelBuilder.HasSequence("SEQ_TIPO_AEROGENERADOR");

            modelBuilder.HasSequence("SEQ_TIPO_CLASE_CARGA");

            modelBuilder.HasSequence("SEQ_TIPO_CLIENTE");

            modelBuilder.HasSequence("SEQ_TIPO_CONEXION");

            modelBuilder.HasSequence("SEQ_TIPO_GENERACION");

            modelBuilder.HasSequence("SEQ_TIPO_IDENTIFICACION");

            modelBuilder.HasSequence("SEQ_TIPO_PROYECTO");

            modelBuilder.HasSequence("SEQ_TIPO_SERVICIO");

            modelBuilder.HasSequence("SEQ_TIPO_SOL_RECIBO");

            modelBuilder.HasSequence("SEQ_TIPO_SOL_SERVICIO");

            modelBuilder.HasSequence("SEQ_TIPO_TECNOLOGIA");

            modelBuilder.HasSequence("SEQ_TIPO_TENSION");

            modelBuilder.HasSequence("SEQ_TIPO_TRAMITE_VISITA");

            modelBuilder.HasSequence("SEQ_TIPO_ZONA");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
