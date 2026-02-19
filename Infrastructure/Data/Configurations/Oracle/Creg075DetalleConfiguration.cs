namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075DetalleConfiguration : IEntityTypeConfiguration<Creg075Detalle>
    {
        public void Configure(EntityTypeBuilder<Creg075Detalle> entity)
        {
            entity.ToTable("CREG_075_DETALLES");
            
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.CargaExistente)
                .HasColumnType("NUMBER(12,2)")
                .HasColumnName("CARGA_EXISTENTE");

            entity.Property(e => e.CargaMaximaRequerida)
                .HasColumnType("NUMBER(12,2)")
                .HasColumnName("CARGA_MAXIMA_REQUERIDA");

            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.CodTension)
                .HasPrecision(10)
                .HasColumnName("COD_TENSION");

            entity.Property(e => e.CodTipoSSolicitud)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_S_SOLICITUD");

            entity.Property(e => e.CodTipoSolicitud)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_SOLICITUD");

            entity.Property(e => e.FechaOperacion)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_OPERACION");

            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PROYECTO");

            entity.Property(e => e.NumeroSolicitud)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUMERO_SOLICITUD");

            entity.Property(e => e.OtrotipoSSolicitud)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("OTROTIPO_S_SOLICITUD");

            entity.Property(e => e.SistemaGeneracion)
                .HasPrecision(1)
                .HasColumnName("SISTEMA_GENERACION");

            entity.Property(e => e.Vigencia)
                .HasColumnType("DATE")
                .HasColumnName("VIGENCIA");

            entity.HasOne(d => d.Cod075ConexionNavigation)
                .WithOne(p => p.Creg075Detalles)
                .HasForeignKey<Creg075Detalle>(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_DETALLES_SERVICIO");

            entity.HasOne(d => d.CodTensionNavigation)
                .WithMany(p => p.Creg075Detalles)
                .HasForeignKey(d => d.CodTension)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_DETALLES_T_TENSION");

            entity.HasOne(d => d.CodTipoSolicitudNavigation)
                .WithMany(p => p.Creg075Detalles)
                .HasForeignKey(d => d.CodTipoSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_DETALLES_T_SOLICITUD");
        }
    }
}
