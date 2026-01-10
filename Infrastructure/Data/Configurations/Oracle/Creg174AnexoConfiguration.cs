namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class Creg174AnexoConfiguration : IEntityTypeConfiguration<Creg174Anexo>
    {
        public void Configure(EntityTypeBuilder<Creg174Anexo> entity)
        {
            entity.ToTable("CREG_174_ANEXOS");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.Cod174Autogen)
                .HasPrecision(10)
                .HasColumnName("COD_174_AUTOGEN");

            entity.Property(e => e.CodDocumentosXformulario)
                .HasPrecision(10)
                .HasColumnName("COD_DOCUMENTOS_XFORMULARIO");

            entity.Property(e => e.EstadoDocumento)
                .HasPrecision(10)
                .HasColumnName("ESTADO_DOCUMENTO")
                .HasDefaultValueSql("1");

            entity.Property(e => e.Expedicion)
                .HasColumnType("DATE")
                .HasColumnName("EXPEDICION");

            entity.Property(e => e.ExtDocument)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("EXT_DOCUMENT");

            entity.Property(e => e.NameDocument)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME_DOCUMENT");

            entity.Property(e => e.OriginalNamedoCument)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ORIGINAL_NAMEDO_CUMENT");

            entity.Property(e => e.SendNotification)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("SEND_NOTIFICATION")
                .HasDefaultValueSql("0");

            entity.Property(e => e.SizeDocument)
                .HasPrecision(10)
                .HasColumnName("SIZE_DOCUMENT");

            entity.Property(e => e.UrlDocument)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("URL_DOCUMENT");

            entity.Property(e => e.UrlRelDocument)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("URL_REL_DOCUMENT");

            entity.Property(e => e.ValidationDocument)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("VALIDATION_DOCUMENT")
                .HasDefaultValueSql("0");

            entity.HasOne(d => d.Cod174AutogenNavigation)
                .WithMany(p => p.Creg174Anexos)
                .HasForeignKey(d => d.Cod174Autogen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_174_ANEXOS_SOL");
        }
    }
}
