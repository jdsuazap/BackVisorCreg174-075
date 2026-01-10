namespace Infrastructure.Data.Configurations.SQLContext
{
    using Core.Entities.SQLContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SolServicioConexionFactibilidadConfiguration : IEntityTypeConfiguration<SolServicioConexionFactibilidad>
    {
        public void Configure(EntityTypeBuilder<SolServicioConexionFactibilidad> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__810447399E28E1EE");

            entity.ToTable("SolServicioConexionFactibilidad", "sol");

            entity.Property(e => e.Id)
                .HasColumnName("IdSolServicioConexionFactibilidad");

            entity.Property(e => e.CodUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("7777777");

            entity.Property(e => e.CodUserUpdate)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValue("7777777");

            entity.Property(e => e.DistanciaPuntoConexion)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.FechaFactibilidad)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.Property(e => e.FechaRespuestaFactibilidad).HasColumnType("datetime");

            entity.Property(e => e.GeoReferenciaH)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.GeoReferenciaLatitud)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.GeoReferenciaLongitud)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Info)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("0|0|0");

            entity.Property(e => e.InfoUpdate)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValue("0|0|0");

            entity.Property(e => e.NivelCortocircuitoMonofasico)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.NivelCortocircuitoTrifasico)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.NombreCircuitoBt)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NombreCircuitoBT");

            entity.Property(e => e.NombreCircuitoMt)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NombreCircuitoMT");

            entity.Property(e => e.NumeroCircuitoBt)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NumeroCircuitoBT");

            entity.Property(e => e.NumeroCircuitoMt)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasColumnName("NumeroCircuitoMT");

            entity.Property(e => e.NumeroFactibilidad)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.NumeroNodo)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.SubEstacionPotencia)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.Property(e => e.TransformadorDistribucion)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.CodSolServicioConexionNavigation)
                .WithMany(p => p.SolServicioConexionFactibilidades)
                .HasForeignKey(d => d.CodSolServicioConexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionFactibilidad_SolServicioConexion");            
        }
    }
}
