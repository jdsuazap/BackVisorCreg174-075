namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class CregTipoCompletitudConfiguration : IEntityTypeConfiguration<CregTipoCompletitud>
    {
        public void Configure(EntityTypeBuilder<CregTipoCompletitud> entity)
        {
            entity.ToTable("CREG_TIPO_COMPLETITUD");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .HasColumnName("ESTADO");
        }
    }

}
