namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    public class Creg075FactibilidadDetCuenConfiguration : IEntityTypeConfiguration<Creg075FactibilidadDetCuen>
    {
        public void Configure(EntityTypeBuilder<Creg075FactibilidadDetCuen> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("CREG_075_FACTIBILIDAD_DET_CUEN");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Factibilidad)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("COD_075_FACTIBILIDAD");

            entity.Property(e => e.CodTipoCarga)
                .HasColumnType("NUMBER")
                .ValueGeneratedNever()
                .HasColumnName("COD_TIPO_CARGA");

            entity.Property(e => e.CodTipoClaseCarga)
                .HasColumnType("NUMBER")
                .ValueGeneratedNever()
                .HasColumnName("COD_TIPO_CLASE_CARGA");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .ValueGeneratedOnAdd()
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("'1' ");

            entity.Property(e => e.ValorCarga)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("VALOR_CARGA");

            entity.HasOne(d => d.CregTipoCliente)
                .WithMany(p => p.Creg075FactibilidadDetCuen)
                .HasForeignKey(d => d.CodTipoCarga)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CREG_075_FACT_TIP_CLIE");


            entity.HasOne(d => d.CregTipoClaseCarga)
                .WithMany(p => p.Creg075FactibilidadDetCuen)
                .HasForeignKey(d => d.CodTipoClaseCarga)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FACTI_DET_CUEN_TIP_CLAS_CAR");

            entity.HasOne(d => d.Creg075Factibilidad)
                .WithMany(p => p.Creg075FactibilidadDetCuen)
                .HasForeignKey(d => d.Cod075Factibilidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_FACTIBILIDAD_DET_CUEN");
        }
    }
}
