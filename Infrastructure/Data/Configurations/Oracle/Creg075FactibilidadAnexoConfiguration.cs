namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075FactibilidadAnexoConfiguration : IEntityTypeConfiguration<Creg075FactibilidadAnexo>
    {
        public void Configure(EntityTypeBuilder<Creg075FactibilidadAnexo> entity)
        {
            entity.ToTable("CREG_075_FACTIBILIDAD_ANEXO");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Factibilidad)
                .HasPrecision(10)
                .HasColumnName("COD_075_FACTIBILIDAD");

            entity.Property(e => e.CodDocumentos)
                .HasPrecision(10)
                .HasColumnName("COD_DOCUMENTOS");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n                         \n\n");

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

            entity.HasOne(d => d.Creg075Factibilidad)
                .WithMany(p => p.Creg075FactibilidadAnexo)
                .HasForeignKey(d => d.Cod075Factibilidad)
                .HasConstraintName("FK_SolServicioConexionFactibilidadAnexo_SolServicioConexionFactibilidad");

            // Definir la relación con DocumentosXFormulario
            entity.HasOne(d => d.CregDocumentosFormulario)
                    .WithMany(p => p.Creg075FactibilidadAnexos)
                    .HasForeignKey(d => d.CodDocumentos)
                    .HasConstraintName("FK_SolServicioConexionFactibilidadAnexo_DocumentosXFormulario");
        }
    }
}
