namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class CregEstadoConfiguration : IEntityTypeConfiguration<CregEstado>
    {
        public void Configure(EntityTypeBuilder<CregEstado> entity)
        {
            entity.ToTable("CREG_ESTADOS");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.CodEtapa)
                .HasPrecision(10)
                .HasColumnName("COD_ETAPA");

            entity.Property(e => e.CodTipoEstado)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_ESTADO")
                .HasDefaultValueSql("1");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1");

            entity.Property(e => e.Homologacion)
                .HasPrecision(10)
                .HasColumnName("HOMOLOGACION");
        }
    }
}
