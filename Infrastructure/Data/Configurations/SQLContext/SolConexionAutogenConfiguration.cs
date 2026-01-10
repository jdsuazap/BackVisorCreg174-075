namespace Infrastructure.Data.Configurations.SQLContext
{
    using Core.Entities.SQLContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SolConexionAutogenConfiguration : IEntityTypeConfiguration<SolConexionAutogen>
    {
        public void Configure(EntityTypeBuilder<SolConexionAutogen> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__tmp_ms_x__5FC381924048A42A");

            entity.ToTable("SolConexionAutogen", "sol");

            entity.Property(e => e.Id).HasColumnName("IdSolConexionAutogen");

            entity.Property(e => e.AprobacionVigencia).HasComment("Validación si esta aprobada o no la vigencia , para realizar la visita");

            entity.Property(e => e.OrinstalaActivos).HasColumnName("ORInstalaActivos");

            entity.Property(e => e.AptoParaConexion).HasComputedColumnSql("(case when [FechaConformidad] IS NOT NULL AND ([DiasValidacionConexion]-datediff(day,[FechaConformidad],getdate()))>=(0) then CONVERT([bit],(1)) else CONVERT([bit],(0)) end)", false);

            entity.Property(e => e.AptoParaDesistimiento).HasComment("Indica si la solicitud es apta para solicitar desistimiento");

            entity.Property(e => e.AptoParaProrroga)
                .HasComputedColumnSql("(case when [FechaConformidad] IS NOT NULL AND ([DiasValidacionProrroga]-datediff(day,[FechaConformidad],getdate()))>=(0) then CONVERT([bit],(1)) else CONVERT([bit],(0)) end)", false)
                .HasComment("Columna calculada, indica si la solicitud es apta para poder solicitar prorroga");

            entity.Property(e => e.AutorizaGastosSuperaLimites).HasComment("Indica si el usuario autoriza que asume los gastos que genere el exceder la capacidad del transformador");

            entity.Property(e => e.BarrioCliente)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Barrio del cliente");

            entity.Property(e => e.CapacidadNominal)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Capacidad nominal o instalada del sistema (kW)");

            entity.Property(e => e.ClienteSuministraMedidor).HasComment("Indica si el cliente suministrara el medidor");

            entity.Property(e => e.CodClasificacionProyecto).HasComment("Clasificacion del proyecto, del solicitante, de acuerdo a su capacidad");

            entity.Property(e => e.CodComercializador).HasComment("Codigo maestro de Comercializador");

            entity.Property(e => e.CodCuentaCliente).HasComment("Codigo de cuenta del solicitante, si es atendido por la empresa directamente");

            entity.Property(e => e.CodDepartamentoCliente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Codigo de departamento al que pertenece el cliente");

            entity.Property(e => e.CodEstratoCliente).HasComment("Codigo maestro de EstratoSocioeconomico. Estrato del cliente, si es de tipo cliente Residencial");

            entity.Property(e => e.CodMunicipioCliente)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasComment("Codigo de municipio al que pertenece el cliente");

            entity.Property(e => e.CodTipoCliente).HasComment("Codigo del tipo de cliente");

            entity.Property(e => e.CodTipoGeneracion).HasComment("Codigo del tipo de Generación al que pertenece el solicitante");

            entity.Property(e => e.CodTipoIdentificacionCliente).HasComment("Codigo del tipo de identificacion");

            entity.Property(e => e.CodTipoProcedimientoConexion).HasComment("Codigo maestro de TipoProcedimientoConexion");

            entity.Property(e => e.CodTransformador)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("Si entrega excedentes, codigo de la subestacion, transformador o circuito al cual se realizara la conexion");

            entity.Property(e => e.CodSubestacion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("Codigo de subestacion del transformador");

            entity.Property(e => e.CodUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cedula del usuario que crea el registro");

            entity.Property(e => e.CodUserUpdate)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cedula del ultimo usuario que actualizó el registro");

            entity.Property(e => e.CodUsuario).HasComment("Codigo maestro de usuario (cliente)");

            entity.Property(e => e.CodigoSic)
                .HasColumnName("CodigoSIC")
                .HasComment("Codigo SIC (Frontera) del otro comercializador por el que es atendido");

            entity.Property(e => e.ContratoConexion)
                .HasComment("Indica si se envió el contrato de conexión al usuario cliente");

            entity.Property(e => e.ContratoConexionFirmado)
                .HasComment("Indica si el contrato de conexión se adjunto por el usuario cliente");

            entity.Property(e => e.DesconexionVoluntaria)
                .HasComment("Indica si el OR solicita desconexion voluntaria al cliente");

            entity.Property(e => e.DiasFaltantesConexion)
                .HasComputedColumnSql("([DiasValidacionConexion]-datediff(day,[FechaConformidad],getdate()))", false)
                .HasComment("Dias que faltan para terminar el plazo para que se pueda colocar la solicitud En Conexión");

            entity.Property(e => e.DiasFaltantesProrroga)
                .HasComputedColumnSql("([DiasValidacionProrroga]-datediff(day,[FechaConformidad],getdate()))", false)
                .HasComment("Dias que faltan para terminar el plazo para que se pueda realizar una prorroga a la solicitud");

            entity.Property(e => e.DiasValidacionConexion).HasComment("Dias a tener en cuenta para validar que la solicitud pueda colocarse en Conexión");

            entity.Property(e => e.DiasValidacionProrroga).HasComment("Dias a tener en cuenta para validar que la solicitud pueda realizar prorroga");

            entity.Property(e => e.DireccionCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Direccion del cliente");

            entity.Property(e => e.DocumentacionRetieAprobada).HasComment("Indica si se aprobó el RETIE que se anexó");

            entity.Property(e => e.DocumentacionVisitaEntregada).HasComment("Indica si se anexó la documentación de la visita");

            entity.Property(e => e.EmailCliente)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Email del cliente");

            entity.Property(e => e.EntregaExcedentes).HasComment("Indica si el solicitante entrega excedentes a la red");

            entity.Property(e => e.EsEditable).HasComment("Indica si la solicitud esta habilitada para editar los datos por el usuario");

            entity.Property(e => e.Estado).HasComment("Codigo maestro de Estados");

            entity.Property(e => e.EstadoVisita).HasComment("Estado de la visita en flujo de desconexion");

            entity.Property(e => e.EstadoAnteriorProrroga).HasComment("Estado del flujo principal en el que estaba la solicitud cuando se creó la prórroga");

            entity.Property(e => e.FechaConformidad)
                .HasColumnType("datetime")
                .HasComment("Fecha en que se da la conformidad a una solicitud");

            entity.Property(e => e.FechaLimiteConexion)
                .HasColumnType("datetime")
                .HasComputedColumnSql("(dateadd(day,[DiasValidacionConexion],[FechaConformidad]))", false)
                .HasComment("Fecha limite para que la solicitud se pueda colocar En Conexión");

            entity.Property(e => e.FechaLimiteProrroga)
                .HasColumnType("datetime")
                .HasComputedColumnSql("(dateadd(day,[DiasValidacionProrroga],[FechaConformidad]))", false)
                .HasComment("Fecha limite para que se pueda realizar una prorroga a la solicitud");

            entity.Property(e => e.FechaPrevistaOper)
                .HasColumnType("datetime")
                .HasComment("Fecha Prevista para la entrada en operacion");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.Info)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la direccion ip, navegador y version del navegador del cliente.");

            entity.Property(e => e.InfoUpdate)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la ultima direccion ip, navegador y version del navegador del cliente.");

            entity.Property(e => e.MedidorBidireccional).HasComment("Indica si el medidor es bidireccional");

            entity.Property(e => e.MedidorPerfilHorario).HasComment("Indica si el medidor tiene perfil horario");

            entity.Property(e => e.NivelTension)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Nivel de tension (kV)");

            entity.Property(e => e.NombreCliente)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Nombre del solicitante");

            entity.Property(e => e.NombreOtroComercializador)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Nombre del comercializador que atiende al solicitante");

            entity.Property(e => e.NumeroIdentificacionCliente)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComment("Numero de identificacion del cliente");

            entity.Property(e => e.NumeroRadicado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Numero de radicado generado para la solicitud (Generado automaticamente)");

            entity.Property(e => e.Observaciones)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("Aclaraciones que desee realizar, el solicitante, sobre el proyecto");

            entity.Property(e => e.OtroTipoCliente)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Corresponde a Otros tipos de clientes");

            entity.Property(e => e.PotenciaMaximaDeclarada)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Potencia maxima declarada (kW)");

            entity.Property(e => e.ProrrogaEnProceso).HasComment("Indica si la solicitud tiene una prorroga");

            entity.Property(e => e.ProtAntiIslaDescFuncionAntiIsla)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("Si ProtAntiIsla_FuncionProteccion es NO, como se garantiza la funcion de la proteccion AntiIsla (arreglo de protecciones)");

            entity.Property(e => e.ProtAntiIslaFuncionProteccion).HasComment("Para sistemas de generacion basados en inversores o aerogeneradores, indica si la funcion de proteccion esta en dichos elementos");

            entity.Property(e => e.SuperaLimiteTransformador).HasComment("Indica si la solicitud supera los limites de la capacidad del transformador a conectarse");

            entity.Property(e => e.TelefonoCliente)
                .HasColumnType("numeric(10, 0)")
                .HasComment("Telefono del cliente");

            entity.Property(e => e.UltimoEstadoProrroga).HasComment("Estado actual de la solicitud de prorroga para los AGGE");

            entity.Property(e => e.UltimoHallazgoFueGrave).HasComment("Indica si el hallazgo fue grave (Procedimiento de Desconexión)");          

            entity.HasOne(d => d.CodDepartamentoClienteNavigation)
                .WithMany(p => p.SolConexionAutogens)
                .HasForeignKey(d => d.CodDepartamentoCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolConexionAutogen_Departamento");

            entity.HasOne(d => d.CodMunicipioClienteNavigation)
                .WithMany(p => p.SolConexionAutogens)
                .HasForeignKey(d => d.CodMunicipioCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolConexionAutogen_Municipio");

            // Ignorar propiedades no mapeadas
            entity.Ignore(e => e.RequiereRETIE);
            entity.Ignore(e => e.MsgRequiereRETIE);
            entity.Ignore(e => e.RequiereContrato);
            entity.Ignore(e => e.MsgRequiereContrato);
            entity.Ignore(e => e.ExcedeVisitaConexionRechazo);
        }
    }
}
