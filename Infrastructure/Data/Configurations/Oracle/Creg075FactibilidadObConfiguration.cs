namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class Creg075FactibilidadObConfiguration: IEntityTypeConfiguration<Creg075FactibilidadObs>
    {
        public void Configure(EntityTypeBuilder<Creg075FactibilidadObs> entity)
        {
            entity.ToTable("CREG_075_FACTIBILIDAD_OBS");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .ValueGeneratedOnAdd()
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Factibilidad)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_075_FACTIBILIDAD");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1 ");

            entity.Property(e => e.GestionadoPor)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("GESTIONADO_POR");

            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PROYECTO");

            entity.Property(e => e.Observacion)
                .IsUnicode(false)
                .HasColumnName("OBSERVACION");

            entity.HasOne(d => d.Creg075Factibilidad)
                .WithOne(p => p.Creg075FactibilidadObs)
                .HasForeignKey<Creg075FactibilidadObs>(d => d.Cod075Factibilidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREG_075_FACT_OBS_SER");
        }
    }
}
