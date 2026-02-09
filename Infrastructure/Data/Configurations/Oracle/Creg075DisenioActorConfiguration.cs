namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075DisenioActorConfiguration : IEntityTypeConfiguration<Creg075DisenioActor>
    {
        public void Configure(EntityTypeBuilder<Creg075DisenioActor> entity)
        {
            entity.ToTable("CREG_075_DISENIO_ACTOR");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.Cedula)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CEDULA");

            entity.Property(e => e.Cod075Disenio)
                .HasPrecision(10)
                .HasColumnName("COD_075_DISENIO");

            entity.Property(e => e.Correo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CORREO");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n\n");

            entity.Property(e => e.Firma)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("FIRMA");

            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.Property(e => e.Telefono)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");

            entity.Property(e => e.TipoActor)
                .HasPrecision(10)
                .HasColumnName("TIPO_ACTOR");

            entity.HasOne(d => d.Creg075Disenio)
                .WithMany(p => p.Creg075DisenioActor)
                .HasForeignKey(d => d.Cod075Disenio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Diseño_DiseñoActor");
        }
    }
}
