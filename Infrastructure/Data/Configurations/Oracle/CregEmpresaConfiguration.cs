namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;

    internal class CregEmpresaConfiguration : IEntityTypeConfiguration<CregEmpresa>
    {
        public void Configure(EntityTypeBuilder<CregEmpresa> entity)
        {
            entity.ToTable("CREG_EMPRESA");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.Abreviatura)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("ABREVIATURA");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CIUDAD");

            entity.Property(e => e.CodArchivo)
                .HasMaxLength(450)
                .IsUnicode(false)
                .HasColumnName("COD_ARCHIVO")
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.CuentaApot)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CUENTA_APOT")
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n   ");

            entity.Property(e => e.IsBimestralApot)
                .IsRequired()
                .HasPrecision(1)
                .HasColumnName("IS_BIMESTRAL_APOT")
                .HasDefaultValueSql("0");

            entity.Property(e => e.Nit)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("NIT")
                .HasDefaultValueSql("'0'");

            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.Property(e => e.NombreGnr)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_GNR");

            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TELEFONO");

            entity.Property(e => e.TipoDocAltApot)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("TIPO_DOC_ALT_APOT");

            entity.Property(e => e.Tope)
                .HasColumnType("NUMBER(18,2)")
                .HasColumnName("TOPE")
                .HasDefaultValueSql("100000");

            entity.Property(e => e.TrbCodTrabRepLegal)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("TRB_COD_TRAB_REP_LEGAL");
        }
         
    }
}
