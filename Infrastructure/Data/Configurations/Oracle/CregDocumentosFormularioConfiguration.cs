namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class CregDocumentosFormularioConfiguration : IEntityTypeConfiguration<CregDocumentosFormulario>
    {
        public void Configure(EntityTypeBuilder<CregDocumentosFormulario> entity)
        {
            entity.ToTable("CREG_DOCUMENTOS_FORMULARIO");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.CodFormulario)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_FORMULARIO")
                .HasDefaultValueSql("1");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1 ");

            entity.Property(e => e.IsCampo)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("IS_CAMPO")
                .HasDefaultValueSql("1 ");

            entity.Property(e => e.Limitload)
                .HasPrecision(19)
                .HasColumnName("LIMITLOAD")
                .HasDefaultValueSql("0 ");

            entity.Property(e => e.NombreDocumento)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_DOCUMENTO");

            entity.Property(e => e.Requiered)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("REQUIERED")
                .HasDefaultValueSql("0 ");

            entity.Property(e => e.Vigencia)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("VIGENCIA")
                .HasDefaultValueSql("0 ");

            entity.Property(e => e.VigenciaMaxima)
                .HasPrecision(10)
                .HasColumnName("VIGENCIA_MAXIMA");

        }
    }
}
