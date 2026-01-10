namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class Creg174BasInvConfiguration : IEntityTypeConfiguration<Creg174BasInv>
    {
        public void Configure(EntityTypeBuilder<Creg174BasInv> entity)
        {
            entity.ToTable("CREG_174_BAS_INV");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.AnioIec61727)
                .HasPrecision(4)
                .HasColumnName("ANIO_IEC61727");

            entity.Property(e => e.AnioUl1741)
                .HasPrecision(4)
                .HasColumnName("ANIO_UL1741");

            entity.Property(e => e.CapacidadDc)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("CAPACIDAD_DC");

            entity.Property(e => e.Cod174Autogen)
                .HasPrecision(10)
                .HasColumnName("COD_174_AUTOGEN");

            entity.Property(e => e.CumpleIec61727)
                .HasPrecision(1)
                .HasColumnName("CUMPLE_IEC61727");

            entity.Property(e => e.CumpleUl1741)
                .HasPrecision(1)
                .HasColumnName("CUMPLE_UL1741");

            entity.Property(e => e.DescripcionElementos)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION_ELEMENTOS");

            entity.Property(e => e.FabricanteInv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FABRICANTE_INV");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_REGISTRO")
                .HasDefaultValueSql("SYSDATE ");

            entity.Property(e => e.ModeloInv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MODELO_INV");

            entity.Property(e => e.NumFases)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("NUM_FASES");

            entity.Property(e => e.NumInversores)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("NUM_INVERSORES");

            entity.Property(e => e.NumPaneles)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("NUM_PANELES");

            entity.Property(e => e.PoseePpc)
                .HasPrecision(1)
                .HasColumnName("POSEE_PPC");

            entity.Property(e => e.PoseeRele)
                .HasPrecision(1)
                .HasColumnName("POSEE_RELE");

            entity.Property(e => e.PotTotalAc)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("POT_TOTAL_AC");

            entity.Property(e => e.PotenciaPanel)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("POTENCIA_PANEL");

            entity.Property(e => e.TrafoGrupoConex)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("TRAFO_GRUPO_CONEX");

            entity.Property(e => e.TrafoImpedancia)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("TRAFO_IMPEDANCIA");

            entity.Property(e => e.TrafoPotNominal)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("TRAFO_POT_NOMINAL");

            entity.Property(e => e.VoltEntInv)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("VOLT_ENT_INV");

            entity.Property(e => e.VoltSalInv)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("VOLT_SAL_INV");

            entity.HasOne(d => d.Cod174AutogenNavigation)
                .WithMany(p => p.Creg174BasInvs)
                .HasForeignKey(d => d.Cod174Autogen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_174_BAS_INV_AUTOGEN");
        }
    }
}
