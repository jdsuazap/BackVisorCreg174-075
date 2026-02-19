namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075PasosConfiguration : IEntityTypeConfiguration<Creg075Pasos>
    {
        public void Configure(EntityTypeBuilder<Creg075Pasos> entity)
        {
            entity.ToTable("CREG_075_PASOS");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.CodEstado)
                .HasPrecision(10)
                .HasColumnName("COD_ESTADO");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1");

            entity.Property(e => e.Etapa)
                .HasPrecision(10)
                .HasColumnName("ETAPA")
                .HasDefaultValueSql("1");

            entity.HasOne(d => d.CregEstado)
                .WithMany(p => p.Creg075Pasos)
                .HasForeignKey(d => d.CodEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PasosSolServicioConexion_Estados");

            entity.HasOne(d => d.Creg075ServicioConexion)
                .WithMany(p => p.Creg075Pasos)
                .HasForeignKey(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PasosSolServicioConexion_SolServicioConexion");
        }
    }
}
