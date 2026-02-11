namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075DisenioConfiguration : IEntityTypeConfiguration<Creg075Disenio>
    {
        public void Configure(EntityTypeBuilder<Creg075Disenio> entity)
        {
            entity.ToTable("CREG_075_DISENIO");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .HasColumnName("ID");


            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.CodFactibilidad)
                .HasPrecision(19)
                .HasColumnName("COD_FACTIBILIDAD");

            entity.Property(e => e.TipoDocumento)
                .HasPrecision(10)
                .HasColumnName("TIPO_DOCUMENTO");

            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PROYECTO");

            entity.Property(e => e.NombreConstructora)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CONSTRUCTORA");

            entity.Property(e => e.Nit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NIT");

            entity.Property(e => e.TieneDocumentacion)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("TIENE_DOCUMENTACION")
                .HasDefaultValueSql("0 ");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1");

            entity.Property(e => e.Etapa)
                .HasPrecision(10)
                .HasColumnName("ETAPA")
                .HasDefaultValueSql("1");

            entity.Property(e => e.CedulaObservaciones)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CEDULA_OBSERVACIONES")
                .HasDefaultValueSql("'' ");

            entity.Property(e => e.NombreObservaciones)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_OBSERVACIONES")
                .HasDefaultValueSql("'' ");


            entity.HasOne(d => d.Creg075ServicioConexion)
                .WithMany(p => p.Creg075Disenios)
                .HasForeignKey(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_DISENIO_SERVICIO");

            entity.HasOne(d => d.Creg075Factibilidad)
                .WithMany(p => p.Creg075Disenios)
                .HasForeignKey(d => d.CodFactibilidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_DISENIO_FACTIBILIDAD");
        }
    }
}
