namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class Creg075ReciboTecnicoAnexoConfiguration : IEntityTypeConfiguration<Creg075ReciboTecnicoAnexo>
    {
        public void Configure(EntityTypeBuilder<Creg075ReciboTecnicoAnexo> entity)
        {
            entity.ToTable("CREG_075_RECIBO_TECNICO_ANEXO");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.Cod075ReciboTecnico)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("COD_075_RECIBO_TECNICO");

            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.CodDocumentos)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("COD_DOCUMENTOS");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .ValueGeneratedNever()
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n    ");

            entity.Property(e => e.EstadoDocumento)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ESTADO_DOCUMENTO")
                .HasDefaultValueSql("1 ");

            entity.Property(e => e.Expedicion)
                .HasColumnType("DATE")
                .ValueGeneratedNever()
                .HasColumnName("EXPEDICION");

            entity.Property(e => e.ExtDocument)
                .HasMaxLength(30)
                .IsUnicode(false)
                .ValueGeneratedNever()
                .HasColumnName("EXT_DOCUMENT");

            entity.Property(e => e.NameDocument)
                .HasMaxLength(100)
                .IsUnicode(false)
                .ValueGeneratedNever()
                .HasColumnName("NAME_DOCUMENT");

            entity.Property(e => e.OriginalNameDocument)
                .HasMaxLength(100)
                .IsUnicode(false)
                .ValueGeneratedNever()
                .HasColumnName("ORIGINAL_NAME_DOCUMENT");

            entity.Property(e => e.SizeDocument)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("SIZE_DOCUMENT");

            entity.Property(e => e.UrlDocument)
                .HasMaxLength(300)
                .IsUnicode(false)
                .ValueGeneratedNever()
                .HasColumnName("URL_DOCUMENT");

            entity.Property(e => e.UrlRelDocument)
                .HasMaxLength(300)
                .IsUnicode(false)
                .ValueGeneratedNever()
                .HasColumnName("URL_REL_DOCUMENT");

            entity.Property(e => e.ValidationDocument)
                .IsRequired()
                .HasPrecision(1)
                .ValueGeneratedNever()
                .HasColumnName("VALIDATION_DOCUMENT")
                .HasDefaultValueSql("0 ");

            entity.HasOne(d => d.CregDocumentosFormulario)
                    .WithMany(p => p.Creg075ReciboTecnicoAnexo)
                    .HasForeignKey(d => d.CodDocumentos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREG_075_REC_TEC_AN_DOCU");

            entity.HasOne(d => d.Creg075ReciboTecnico)
                .WithMany(p => p.Creg075ReciboTecnicoAnexo)
                .HasForeignKey(d => d.Cod075ReciboTecnico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREG_075_REC_TEC_AN_REC");

            entity.HasOne(d => d.Creg075ServicioConexion)
                .WithMany(p => p.Creg075ReciboTecnicoAnexo)
                .HasForeignKey(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREG_075_REC_TEC_AN_CON");
        }
    }
}
