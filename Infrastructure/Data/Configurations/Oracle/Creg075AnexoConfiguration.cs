namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075AnexoConfiguration : IEntityTypeConfiguration<Creg075Anexo>
    {
        public void Configure(EntityTypeBuilder<Creg075Anexo> entity)
        {
            entity.ToTable("CREG_075_ANEXOS");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.CodDocumentos)
                .HasPrecision(10)
                .HasColumnName("COD_DOCUMENTOS");

            entity.Property(e => e.EstadoDocumento)
                .HasPrecision(10)
                .HasColumnName("ESTADO_DOCUMENTO");

            entity.Property(e => e.Expedicion)
                .HasColumnType("DATE")
                .HasColumnName("EXPEDICION");

            entity.Property(e => e.ExtDocument)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("EXT_DOCUMENT");

            entity.Property(e => e.NameDocument)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NAME_DOCUMENT");

            entity.Property(e => e.OriginalDocument)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ORIGINAL_DOCUMENT");

            entity.Property(e => e.SendNotification)
                .HasPrecision(1)
                .HasColumnName("SEND_NOTIFICATION");

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
                .HasPrecision(1)
                .HasColumnName("VALIDATION_DOCUMENT");

            entity.HasOne(d => d.Cod075ConexionNavigation)
                .WithMany(p => p.Creg075Anexos)
                .HasForeignKey(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREG_075_ANEXOS_SERVICIO");

            entity.HasOne(d => d.CodDocumentosNavigation)
                .WithMany(p => p.Creg075Anexos)
                .HasForeignKey(d => d.CodDocumentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_ANEXOS_DOC_FORM");
        }
    }
}
