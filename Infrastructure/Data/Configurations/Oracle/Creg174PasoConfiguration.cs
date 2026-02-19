namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg174PasoConfiguration : IEntityTypeConfiguration<Creg174Pasos>
    {
        public void Configure(EntityTypeBuilder<Creg174Pasos> entity)
        {
            entity.ToTable("CREG_174_PASOS");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.Cod174Autogen)
                .HasPrecision(10)
                .HasColumnName("COD_174_AUTOGEN");

            entity.Property(e => e.CodEstado)
                .HasPrecision(10)
                .HasColumnName("COD_ESTADO");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_REGISTRO")
                .HasDefaultValueSql("SYSDATE ");

            entity.Property(e => e.IdEmpresa)
                .HasPrecision(10)
                .HasColumnName("ID_EMPRESA");

            entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasPrecision(1)
                    .HasColumnName("ESTADO")
                    .HasDefaultValueSql("1 ");
        }
    }
}
