namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class Creg174InmuebleConfiguration : IEntityTypeConfiguration<Creg174Inmueble>
    {
        public void Configure(EntityTypeBuilder<Creg174Inmueble> entity)
        {
            entity.ToTable("CREG_174_INMUEBLE");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.Cod174Autogen)
                .HasPrecision(10)
                .HasColumnName("COD_174_AUTOGEN");

            entity.Property(e => e.Corregimiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CORREGIMIENTO");

            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_REGISTRO")
                .HasDefaultValueSql("SYSDATE ");

            entity.Property(e => e.Municipio)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("MUNICIPIO");

            entity.Property(e => e.NumeroPosteTransformador)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NUMERO_POSTE_TRANSFORMADOR");

            entity.Property(e => e.UbicacionGeowgs)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UBICACION_GEOWGS");

            entity.Property(e => e.Vereda)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("VEREDA");

            entity.HasOne(d => d.Cod174AutogenNavigation)
                .WithMany(p => p.Creg174Inmuebles)
                .HasForeignKey(d => d.Cod174Autogen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_174_INMUEBLE_AUTOGEN");
        }
    }
}
