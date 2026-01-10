namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class CregClasificacionProyectoConfiguration : IEntityTypeConfiguration<CregClasificacionProyecto>
    {
        public void Configure(EntityTypeBuilder<CregClasificacionProyecto> entity)
        {
            entity.ToTable("CREG_CLASIFICACION_PROYECTO");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
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
        }
    }
}
