namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class Creg174InfoeolicaConfiguration : IEntityTypeConfiguration<Creg174Infoeolica>
    {
        public void Configure(EntityTypeBuilder<Creg174Infoeolica> entity)
        {
            entity.ToTable("CREG_174_INFOEOLICA");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.AnioIeee1547)
                .HasPrecision(4)
                .HasColumnName("ANIO_IEEE1547");

            entity.Property(e => e.Cod174Autogen)
                .HasPrecision(10)
                .HasColumnName("COD_174_AUTOGEN");

            entity.Property(e => e.CodTipoAerogenerador)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_TIPO_AEROGENERADOR");

            entity.Property(e => e.CumpleIeee1547)
                .HasPrecision(1)
                .HasColumnName("CUMPLE_IEEE1547");

            entity.Property(e => e.DescripcionElementos)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION_ELEMENTOS");

            entity.Property(e => e.FabricanteAerogenerador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("FABRICANTE_AEROGENERADOR");

            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MODELO");

            entity.Property(e => e.NumAerogeneradores)
                .HasPrecision(6)
                .HasColumnName("NUM_AEROGENERADORES");

            entity.Property(e => e.PoseePpc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("POSEE_PPC");

            entity.Property(e => e.PotenciaNominal)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("POTENCIA_NOMINAL");

            entity.Property(e => e.TransfoGrupoconex)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("TRANSFO_GRUPOCONEX");

            entity.Property(e => e.TransfoImpedanciacc)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("TRANSFO_IMPEDANCIACC");

            entity.Property(e => e.TransfoPotnominal)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("TRANSFO_POTNOMINAL");

            entity.Property(e => e.VoltajeAc)
                .HasColumnType("NUMBER(10,4)")
                .HasColumnName("VOLTAJE_AC");

            entity.HasOne(d => d.Cod174AutogenNavigation)
                .WithOne(p => p.Creg174Infoeolica)
                .HasForeignKey<Creg174Infoeolica>(d => d.Cod174Autogen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_174_INFOEOLICA_AUTOGEN");
        }
    }
}
