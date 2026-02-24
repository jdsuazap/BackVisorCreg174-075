namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075FactibilidadConfiguration : IEntityTypeConfiguration<Creg075Factibilidad>
    {
        public void Configure(EntityTypeBuilder<Creg075Factibilidad> entity)
        {
            entity.ToTable("CREG_075_FACTIBILIDAD");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");

            entity.Property(e => e.Altura)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ALTURA");

            entity.Property(e => e.CargaAprobada)
                .HasPrecision(19)
                .HasColumnName("CARGA_APROBADA");

            entity.Property(e => e.CargaExistente)
                .HasPrecision(19)
                .HasColumnName("CARGA_EXISTENTE");

            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.CodTipoSolicitud)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_SOLICITUD");

            entity.Property(e => e.DistanciaPuntoConexion)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("DISTANCIA_PUNTO_CONEXION");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .HasColumnName("ESTADO");

            entity.Property(e => e.FechaFactibilidad)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_FACTIBILIDAD")
                .HasDefaultValueSql("SYSDATE ");

            entity.Property(e => e.FechaRespuestaFactibilidad)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_RESPUESTA_FACTIBILIDAD")
                .HasDefaultValueSql("SYSDATE ");

            entity.Property(e => e.Latitud)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LATITUD");

            entity.Property(e => e.Longitud)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LONGITUD");

            entity.Property(e => e.NivelAprobacion)
                .HasPrecision(10)
                .HasColumnName("NIVEL_APROBACION");

            entity.Property(e => e.NivelMonofasico)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NIVEL_MONOFASICO");

            entity.Property(e => e.NivelTrifasico)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NIVEL_TRIFASICO");

            entity.Property(e => e.NombreCircuitobt)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CIRCUITOBT");

            entity.Property(e => e.NombreCircuitomt)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CIRCUITOMT");

            entity.Property(e => e.NumeroCircuitobt)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NUMERO_CIRCUITOBT");

            entity.Property(e => e.NumeroCircuitomt)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NUMERO_CIRCUITOMT");

            entity.Property(e => e.NumeroFactibilidad)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NUMERO_FACTIBILIDAD");

            entity.Property(e => e.NumeroNodo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NUMERO_NODO");

            entity.Property(e => e.SubestacionPotencia)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("SUBESTACION_POTENCIA");

            entity.Property(e => e.TransformadorDistribucion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TRANSFORMADOR_DISTRIBUCION");

            entity.Property(e => e.VigenciaFactibilidad)
                .HasPrecision(19)
                .HasColumnName("VIGENCIA_FACTIBILIDAD");

            entity.HasOne(d => d.Creg075ServicioConexion)
                .WithMany(p => p.Creg075Factibilidads)
                .HasPrincipalKey(p => p.Id)
                .HasForeignKey(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_FACTIBILIDAD_SERVICIO");

            entity.HasOne(d => d.CregTipoSolicitudRecibo)
                .WithMany(p => p.Creg075Factibilidads)
                .HasForeignKey(d => d.CodTipoSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_FACTIBILIDAD_T_SOL");

            entity.HasOne(d => d.CregTipoTension)
               .WithMany(p => p.Creg075Factibilidad)
               .HasForeignKey(d => d.NivelAprobacion)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_CREG_FACTIBILIDAD_NIVEL_T");
        }
    }
}
