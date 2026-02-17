namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075DisenioAnexoConfiguration : IEntityTypeConfiguration<Creg075DisenioAnexo>
    {
        public void Configure(EntityTypeBuilder<Creg075DisenioAnexo> entity)
        {
            entity.ToTable("CREG_075_DISENIO_ANEXO");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.Cod075Disenio)
                .HasPrecision(19)
                .HasColumnName("COD_075_DISENIO");

            entity.Property(e => e.CodDocumentos)
                .HasPrecision(10)
                .HasColumnName("COD_DOCUMENTOS");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n");

            entity.Property(e => e.EstadoDocumento)
                .HasPrecision(10)
                .HasColumnName("ESTADO_DOCUMENTO")
                .HasDefaultValueSql("1 ");

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

            entity.Property(e => e.OriginalNameDocument)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ORIGINAL_NAME_DOCUMENT");

            entity.Property(e => e.SendNotification)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("SEND_NOTIFICATION")
                .HasDefaultValueSql("0 ");

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
                .HasDefaultValueSql("0 ");

            // Definir relaciones
            entity.HasOne(d => d.Creg075Disenio)
                .WithMany(p => p.Creg075DisenioAnexo)
                .HasForeignKey(d => d.Cod075Disenio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Disenio_SolServicioConexionFactibilidadAnexo");

            entity.HasOne(d => d.CregDocumentosFormulario)
                .WithMany(p => p.Creg075DisenioAnexos)
                .HasForeignKey(d => d.CodDocumentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionDisenioAnexo_DocumentosXFormulario");

            entity.HasOne(d => d.Creg075ServicioConexion)
                .WithMany(p => p.Creg075DisenioAnexos)
                .HasForeignKey(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicio_FactibilidadDisenio");
        }
    }
}
