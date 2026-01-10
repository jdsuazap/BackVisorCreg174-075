namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class CregTipoProyectoConfiguration : IEntityTypeConfiguration<CregTipoProyecto>
    {
        public void Configure(EntityTypeBuilder<CregTipoProyecto> entity)
        {
            entity.ToTable("CREG_TIPO_PROYECTO");

            entity.Property(e => e.Id)
                .HasPrecision(10)
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
