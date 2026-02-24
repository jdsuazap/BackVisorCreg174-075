namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    public class Creg075FactibilidadDocuConfiguration : IEntityTypeConfiguration<Creg075FactibilidadDocu>
    {
        public void Configure(EntityTypeBuilder<Creg075FactibilidadDocu> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("CREG_075_FACTIBILIDAD_DOCU");

            entity.Property(e => e.Id)
                .HasPrecision(19)
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Factibilidad)
                .HasPrecision(19)
                .HasColumnName("COD_075_FACTIBILIDAD");

            entity.Property(e => e.CodDocumentos)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_DOCUMENTOS");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1 \n");

            entity.Property(e => e.Valor)
                .HasPrecision(1)
                .HasColumnName("VALOR")
                .HasDefaultValueSql("0 \n");

            entity.HasOne(d => d.Creg075Factibilidad)
                .WithMany(p => p.Creg075FactibilidadDocu)
                .HasForeignKey(d => d.Cod075Factibilidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREG_075_FACT_DOC_FAC");

            entity.HasOne(d => d.CregDocumentosFormulario)
                .WithMany(p => p.Creg075FactibilidadDocu)
                .HasForeignKey(d => d.CodDocumentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREG_075_FACT_DOC_DOC");
        }
    }
}
