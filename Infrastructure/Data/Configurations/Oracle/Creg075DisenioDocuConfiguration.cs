namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    public class Creg075DisenioDocuConfiguration : IEntityTypeConfiguration<Creg075DisenioDocu>
    {
        public void Configure(EntityTypeBuilder<Creg075DisenioDocu> entity)
        {
            entity.ToTable("CREG_075_DISENIO_DOCU");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Conexion)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.Cod075Disenio)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_075_DISENIO");

            entity.Property(e => e.CodDocumentos)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_DOCUMENTOS");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1 \n");

            entity.Property(e => e.Valor)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("VALOR")
                .HasDefaultValueSql("0 ");

            entity.HasOne(d => d.Creg075ServicioConexion)
                .WithMany(p => p.Creg075DisenioDocu)
                .HasForeignKey(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_DISENIO_DOCU_SER");

            entity.HasOne(d => d.Creg075Disenio)
                .WithMany(p => p.Creg075DisenioDocu)
                .HasForeignKey(d => d.Cod075Disenio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Disenio_DisenioDocumento");

            entity.HasOne(d => d.CregDocumentosFormulario)
                .WithMany(p => p.Creg075DisenioDocu)
                .HasForeignKey(d => d.CodDocumentos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Documento_DisenioDocumento");
        }
    }
}
