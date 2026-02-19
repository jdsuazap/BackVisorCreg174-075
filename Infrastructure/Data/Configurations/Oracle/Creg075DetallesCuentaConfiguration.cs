namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075DetallesCuentaConfiguration : IEntityTypeConfiguration<Creg075DetallesCuenta>
    {
        public void Configure(EntityTypeBuilder<Creg075DetallesCuenta> entity)
        {
            entity.ToTable("CREG_075_DETALLES_CUENTAS");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.CodTipoCarga)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_CARGA");

            entity.Property(e => e.CodTipoClaseCarga)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_CLASE_CARGA");

            entity.Property(e => e.ValorCarga)
                .HasColumnType("NUMBER(12,2)")
                .HasColumnName("VALOR_CARGA");

            entity.HasOne(d => d.Cod075ConexionNavigation)
                .WithMany(p => p.Creg075DetallesCuentas)
                .HasForeignKey(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_DETALLES_CUENTAS_SER");

            entity.HasOne(d => d.CodTipoClaseCargaNavigation)
                .WithMany(p => p.Creg075DetallesCuenta)
                .HasForeignKey(d => d.CodTipoClaseCarga)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_DET_CUEN_T_CL_CARGA");
        }
    }
}
