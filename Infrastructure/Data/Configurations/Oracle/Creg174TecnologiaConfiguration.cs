namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class Creg174TecnologiaConfiguration : IEntityTypeConfiguration<Creg174Tecnologia>
    {
        public void Configure(EntityTypeBuilder<Creg174Tecnologia> entity)
        {
            entity.ToTable("CREG_174_TECNOLOGIAS");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.AlmacenamientoEnergia)
                .HasPrecision(1)
                .HasColumnName("ALMACENAMIENTO_ENERGIA");

            entity.Property(e => e.BasadoInversores)
                .HasPrecision(1)
                .HasColumnName("BASADO_INVERSORES");

            entity.Property(e => e.BasadoMaqAsincronicas)
                .HasPrecision(1)
                .HasColumnName("BASADO_MAQ_ASINCRONICAS");

            entity.Property(e => e.BasadoMaqSincronicas)
                .HasPrecision(1)
                .HasColumnName("BASADO_MAQ_SINCRONICAS");

            entity.Property(e => e.CapacidadKw)
                .HasPrecision(10)
                .HasColumnName("CAPACIDAD_KW");

            entity.Property(e => e.CapacidadKwh)
                .HasPrecision(10)
                .HasColumnName("CAPACIDAD_KWH");

            entity.Property(e => e.Cod174Autogen)
                .HasPrecision(10)
                .HasColumnName("COD_174_AUTOGEN");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_REGISTRO")
                .HasDefaultValueSql("SYSDATE ");

            entity.Property(e => e.OtraTecnologiaBase)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("OTRA_TECNOLOGIA_BASE");

            entity.HasOne(d => d.Cod174AutogenNavigation)
                .WithOne(p => p.Creg174Tecnologia)
                .HasForeignKey<Creg174Tecnologia>(d => d.Cod174Autogen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_174_TECNOLOGIAS_AUTOGEN");
        }
    }
}
