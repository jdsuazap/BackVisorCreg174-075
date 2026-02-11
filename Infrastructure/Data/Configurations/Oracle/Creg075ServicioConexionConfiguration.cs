namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    internal class Creg075ServicioConexionConfiguration : IEntityTypeConfiguration<Creg075ServicioConexion>
    {
        public void Configure(EntityTypeBuilder<Creg075ServicioConexion> entity)
        {
            {
                entity.ToTable("CREG_075_SERVICIO_CONEXION");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Anulacion)
                            .HasPrecision(1)
                            .HasColumnName("ANULACION")
                            .HasDefaultValueSql("0");

                entity.Property(e => e.Circuito)
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("CIRCUITO");

                entity.Property(e => e.CodActividadEconomica)
                            .HasPrecision(10)
                            .HasColumnName("COD_ACTIVIDAD_ECONOMICA");

                entity.Property(e => e.CodEstado)
                            .HasPrecision(10)
                            .HasColumnName("COD_ESTADO");

                entity.Property(e => e.CodEstrato)
                            .HasPrecision(10)
                            .HasColumnName("COD_ESTRATO");

                entity.Property(e => e.CodEtapa)
                            .HasPrecision(10)
                            .HasColumnName("COD_ETAPA")
                            .HasDefaultValueSql("1 ");

                entity.Property(e => e.CodTipoConexion)
                            .HasPrecision(10)
                            .HasColumnName("COD_TIPO_CONEXION");

                entity.Property(e => e.CodTipoUso)
                            .HasPrecision(10)
                            .HasColumnName("COD_TIPO_USO");

                entity.Property(e => e.DesistirSolicitud)
                            .HasPrecision(1)
                            .HasColumnName("DESISTIR_SOLICITUD")
                            .HasDefaultValueSql("0");

                entity.Property(e => e.DistanciaRed)
                            .HasMaxLength(250)
                            .IsUnicode(false)
                            .HasColumnName("DISTANCIA_RED");

                entity.Property(e => e.DocumentacionCompleta)
                            .HasPrecision(1)
                            .HasColumnName("DOCUMENTACION_COMPLETA")
                            .HasDefaultValueSql("0");

                entity.Property(e => e.Empresa)
                            .HasPrecision(10)
                            .HasColumnName("EMPRESA");

                entity.Property(e => e.ExisteRed)
                            .HasPrecision(1)
                            .HasColumnName("EXISTE_RED");

                entity.Property(e => e.Factibilidad)
                            .HasPrecision(1)
                            .HasColumnName("FACTIBILIDAD")
                            .HasDefaultValueSql("0");

                entity.Property(e => e.FactibilidadApoyo)
                            .HasPrecision(1)
                            .HasColumnName("FACTIBILIDAD_APOYO")
                            .HasDefaultValueSql("0");

                entity.Property(e => e.FechaSolicitud)
                            .HasColumnType("DATE")
                            .HasColumnName("FECHA_SOLICITUD");

                entity.Property(e => e.Nodo)
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("NODO");

                entity.Property(e => e.Normalizacion)
                            .HasPrecision(1)
                            .HasColumnName("NORMALIZACION")
                            .HasDefaultValueSql("0");

                entity.Property(e => e.NormalizacionVisita)
                            .HasPrecision(1)
                            .HasColumnName("NORMALIZACION_VISITA")
                            .HasDefaultValueSql("0");

                entity.Property(e => e.NumeroRadicado)
                            .HasMaxLength(20)
                            .IsUnicode(false)
                            .HasColumnName("NUMERO_RADICADO");

                entity.Property(e => e.ObraConforme)
                            .HasPrecision(1)
                            .HasColumnName("OBRA_CONFORME")
                            .HasDefaultValueSql("0");

                entity.Property(e => e.ObservacionesSolicitante)
                            .HasMaxLength(500)
                            .IsUnicode(false)
                            .HasColumnName("OBSERVACIONES_SOLICITANTE");

                entity.Property(e => e.Otrotipouso)
                            .HasMaxLength(100)
                            .IsUnicode(false)
                            .HasColumnName("OTROTIPOUSO");

                entity.Property(e => e.ReciboTecnico)
                            .HasPrecision(1)
                            .HasColumnName("RECIBO_TECNICO")
                            .HasDefaultValueSql("0");

                entity.Property(e => e.Transformador)
                            .HasMaxLength(50)
                            .IsUnicode(false)
                            .HasColumnName("TRANSFORMADOR");

                entity.HasOne(d => d.CodActividadEconomicaNavigation)
                            .WithMany(p => p.Creg075ServicioConexions)
                            .HasForeignKey(d => d.CodActividadEconomica)
                            .HasConstraintName("CREG_075_SERV_CON_ACTI_ECON");

                entity.HasOne(d => d.CodEstadoNavigation)
                            .WithMany(p => p.Creg075ServicioConexions)
                            .HasForeignKey(d => d.CodEstado)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("CREG_075_SERVI_CON_ESTADO");

                entity.HasOne(d => d.CodEstratoNavigation)
                            .WithMany(p => p.Creg075ServicioConexions)
                            .HasForeignKey(d => d.CodEstrato)
                            .HasConstraintName("CREG_075_SERV_CON_ESTRATO");

                entity.HasOne(d => d.CodEtapaNavigation)
                            .WithMany(p => p.Creg075ServicioConexions)
                            .HasForeignKey(d => d.CodEtapa)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("CREG_075_SERV_CON_ETAPA");

                entity.HasOne(d => d.CodTipoConexionNavigation)
                            .WithMany(p => p.Creg075ServicioConexions)
                            .HasForeignKey(d => d.CodTipoConexion)
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("CREG_075_SERV_CON_T_CON");
                
                entity.HasOne(d => d.CodTipoUsoNavigation)
                    .WithMany(p => p.Creg075ServicioConexion)
                    .HasForeignKey(d => d.CodTipoUso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREG_075_SER_CON_TIP_CLI");
            }
        }
    }
}