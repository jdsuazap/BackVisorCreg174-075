namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075ReciboTecnicoProyConfiguration : IEntityTypeConfiguration<Creg075ReciboTecnicoProy>
    {
        public void Configure(EntityTypeBuilder<Creg075ReciboTecnicoProy> entity)
        {
            entity.ToTable("CREG_075_RECIBO_TECNICO_PROY");

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            entity.Property(e => e.Cod075ReciboTecnico)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_075_RECIBO_TECNICO");

            entity.Property(e => e.CodTipoProyecto)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_TIPO_PROYECTO");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1 ");

            entity.Property(e => e.Etapa)
                .HasColumnType("NUMBER")
                .HasColumnName("ETAPA")
                .HasDefaultValueSql("1 ");

            entity.HasOne(d => d.Creg075ReciboTecnico)
                    .WithMany(p => p.Creg075ReciboTecnicoProy)
                    .HasForeignKey(d => d.Cod075ReciboTecnico)
                    .HasPrincipalKey(p => p.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CREG_075_REC_TECN_PROY");

            entity.HasOne(d => d.CregTipoProyecto)
                .WithMany(p => p.Creg075ReciboTecnicoProy)
                .HasForeignKey(d => d.CodTipoProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREG_075_REC_TEC_TIP_PROY");
        }
    }
}
