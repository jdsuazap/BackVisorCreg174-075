namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class CregTipoGeneracionConfiguration : IEntityTypeConfiguration<CregTipoGeneracion>
    {
        public void Configure(EntityTypeBuilder<CregTipoGeneracion> entity)
        {
            entity.ToTable("CREG_TIPO_GENERACION");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.Abreviatura)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ABREVIATURA");

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
