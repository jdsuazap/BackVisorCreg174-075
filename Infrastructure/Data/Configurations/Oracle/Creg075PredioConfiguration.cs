namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075PredioConfiguration : IEntityTypeConfiguration<Creg075Predio>
    {
        public void Configure(EntityTypeBuilder<Creg075Predio> entity)
        {
            entity.ToTable("CREG_075_PREDIO");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .HasColumnName("ID");

            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.CodDepartamento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("COD_DEPARTAMENTO");

            entity.Property(e => e.CodMunicipio)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("COD_MUNICIPIO");

            entity.Property(e => e.CodTipoConstruccion)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_CONSTRUCCION");

            entity.Property(e => e.CodZona)
                .HasPrecision(10)
                .HasColumnName("COD_ZONA");

            entity.Property(e => e.DescripcionPredio)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION_PREDIO");

            entity.Property(e => e.DireccionPredio)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("DIRECCION_PREDIO");

            entity.Property(e => e.IdentificacionCliente)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("IDENTIFICACION_CLIENTE");

            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOCALIDAD");

            entity.Property(e => e.MatriculaInmobiliaria)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("MATRICULA_INMOBILIARIA");

            entity.Property(e => e.UbicacionH)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UBICACION_H");

            entity.Property(e => e.UbicacionLat)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UBICACION_LAT");

            entity.Property(e => e.UbicacionLong)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UBICACION_LONG");

            entity.HasOne(d => d.Cod075ConexionNavigation)
                .WithOne(p => p.Creg075Predios)
                .HasForeignKey<Creg075Predio>(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_PREDIO_SERVICIO");

            entity.HasOne(d => d.CodDepartamentoNavigation)
                .WithMany(p => p.Creg075Predios)
                .HasForeignKey(d => d.CodDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_PREDIO_DEPTO");

            entity.HasOne(d => d.CodMunicipioNavigation)
                .WithMany(p => p.Creg075Predios)
                .HasForeignKey(d => d.CodMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_PREDIO_CIUDAD");

            entity.HasOne(d => d.CodTipoConstruccionNavigation)
                .WithMany(p => p.Creg075Predios)
                .HasForeignKey(d => d.CodTipoConstruccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_PREDIO_T_CONST");

            entity.HasOne(d => d.CodZonaNavigation)
                .WithMany(p => p.Creg075Predios)
                .HasForeignKey(d => d.CodZona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CREG_075_PREDIO_ZONA");
        }
    }
}
