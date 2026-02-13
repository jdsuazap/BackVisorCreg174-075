namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    public class Creg075FactibilidadProyeConfiguration : IEntityTypeConfiguration<Creg075FactibilidadProye>
    {
        public void Configure(EntityTypeBuilder<Creg075FactibilidadProye> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("CREG_075_FACTIBILIDAD_PROYE");

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Factibilidad)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_075_FACTIBILIDAD");

            entity.Property(e => e.CodTipoProyecto)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_TIPO_PROYECTO");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1 ");

            entity.HasOne(d => d.Creg075Factibilidad)
                .WithMany(p => p.Creg075FactibilidadProye)
                .HasForeignKey(d => d.Cod075Factibilidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_FACT_PROYE_FACT");

            entity.HasOne(d => d.CregTipoProyecto)
                .WithMany(p => p.Creg075FactibilidadProye)
                .HasForeignKey(d => d.CodTipoProyecto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_FACT_PROYE_TIP_PROYE");
        }
    }
}
