namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class Creg174TecnUtilizadaConfiguration : IEntityTypeConfiguration<Creg174TecnUtilizada>
    {
        public void Configure(EntityTypeBuilder<Creg174TecnUtilizada> entity)
        {
            entity.ToTable("CREG_174_TECN_UTILIZADAS");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.CapacidadKwPorTecnologia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CAPACIDAD_KW_POR_TECNOLOGIA");

            entity.Property(e => e.Cod174Autogen)
                .HasPrecision(10)
                .HasColumnName("COD_174_AUTOGEN");

            entity.Property(e => e.CodTipoTecnologia)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_TECNOLOGIA");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_REGISTRO")
                .HasDefaultValueSql("SYSDATE ");

            entity.Property(e => e.OtroTipoTecnologia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OTRO_TIPO_TECNOLOGIA");

            entity.HasOne(d => d.Cod174AutogenNavigation)
                .WithMany(p => p.Creg174TecnUtilizada)
                .HasForeignKey(d => d.Cod174Autogen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_174_TECN_UTIL_AUTOGEN");
        }
    }
}
