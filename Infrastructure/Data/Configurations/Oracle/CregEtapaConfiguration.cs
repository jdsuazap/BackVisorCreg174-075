namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class CregEtapaConfiguration : IEntityTypeConfiguration<CregEtapa>
    {
        public void Configure(EntityTypeBuilder<CregEtapa> entity)
        {
            entity.ToTable("CREG_ETAPAS");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.CodTipoEtapa)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_ETAPA")
                .HasDefaultValueSql("1");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n   ");
        }
    }
}
