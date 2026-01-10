namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class CregTipoTensionConfiguration : IEntityTypeConfiguration<CregTipoTension>
    {
        public void Configure(EntityTypeBuilder<CregTipoTension> entity)
        {
            entity.ToTable("CREG_TIPO_TENSION");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n   ");

            entity.Property(e => e.Nivel)
                .HasPrecision(10)
                .HasColumnName("NIVEL");
        }
    }
}
