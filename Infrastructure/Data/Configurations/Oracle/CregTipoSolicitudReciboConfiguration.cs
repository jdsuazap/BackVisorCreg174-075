namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    internal class CregTipoSolicitudReciboConfiguration : IEntityTypeConfiguration<CregTipoSolicitudRecibo>
    {
        public void Configure(EntityTypeBuilder<CregTipoSolicitudRecibo> entity)
        {
            entity.ToTable("CREG_TIPO_SOLICITUD_RECIBO");

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
