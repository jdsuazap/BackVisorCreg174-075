namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class Creg174NoBasInvConfiguration : IEntityTypeConfiguration<Creg174NoBasInv>
    {
        public void Configure(EntityTypeBuilder<Creg174NoBasInv> entity)
        {
            entity.ToTable("CREG_174_NO_BAS_INV");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.AnioIeee1547)
                .HasPrecision(4)
                .HasColumnName("ANIO_IEEE1547");

            entity.Property(e => e.Cod174Autogen)
                .HasPrecision(10)
                .HasColumnName("COD_174_AUTOGEN");

            entity.Property(e => e.CumpleIeee1547)
                .HasPrecision(1)
                .HasColumnName("CUMPLE_IEEE1547");

            entity.Property(e => e.DescripcionElementos)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION_ELEMENTOS");

            entity.Property(e => e.FabricanteGenerador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FABRICANTE_GENERADOR");

            entity.Property(e => e.FactorPotencia)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("FACTOR_POTENCIA");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_REGISTRO")
                .HasDefaultValueSql("SYSDATE ");

            entity.Property(e => e.ModeloGenerador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MODELO_GENERADOR");

            entity.Property(e => e.NumeroFases)
                .HasPrecision(6)
                .HasColumnName("NUMERO_FASES");

            entity.Property(e => e.PotenciaNominal)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("POTENCIA_NOMINAL");

            entity.Property(e => e.TransfoGrupoConex)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("TRANSFO_GRUPO_CONEX");

            entity.Property(e => e.TransfoImpedancia)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("TRANSFO_IMPEDANCIA");

            entity.Property(e => e.TransfoPotNominal)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("TRANSFO_POT_NOMINAL");

            entity.Property(e => e.VoltajeGenerador)
                .HasPrecision(6)
                .HasColumnName("VOLTAJE_GENERADOR");

            entity.HasOne(d => d.Cod174AutogenNavigation)
                .WithOne(p => p.Creg174NoBasInv)
                .HasForeignKey<Creg174NoBasInv>(d => d.Cod174Autogen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_174_NO_BASADA_INV_AUTOGEN");
        }
    }
}
