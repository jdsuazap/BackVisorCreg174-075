using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class PasosSolConexionAutogenConfiguration : IEntityTypeConfiguration<PasosSolConexionAutogen>
    {
        public void Configure(EntityTypeBuilder<PasosSolConexionAutogen> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__PasosSol__CBFC4C3AF5FEC129");

            entity.ToTable("PasosSolConexionAutogen", "sol");

            entity.Property(e => e.Id)
                .HasColumnName("IdPasosConexionAutogen")
                .HasComment("Id registro");

            entity.Property(e => e.CodEstado).HasComment("Codigo maestro de Estado de Solicitud de Conexion");

            entity.Property(e => e.CodSolConexionAutogen).HasComment("Codigo maestro de Solicitud de Conexion");

            entity.Property(e => e.CodSolConexionAutogenReporteHallazgo).HasComment("Codigo maestro de Reporte de Hallazgo");

            entity.Property(e => e.CodUser)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cedula del usuario que crea el registro");

            entity.Property(e => e.CodUserUpdate)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cedula del ultimo usuario que actualizó el registro");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("Estado del registro (Activo/Inactivo)");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.Info)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la direccion ip, navegador y version del navegador del cliente.");

            entity.Property(e => e.InfoUpdate)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la ultima direccion ip, navegador y version del navegador del cliente.");

            entity.HasOne(d => d.CodEstadoNavigation)
                .WithMany(p => p.PasosSolConexionAutogens)
                .HasForeignKey(d => d.CodEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PasosSolConexionAutogen_Estados");

            entity.HasOne(d => d.CodSolConexionAutogenNavigation)
                .WithMany(p => p.PasosSolConexionAutogens)
                .HasForeignKey(d => d.CodSolConexionAutogen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PasosSolConexionAutogen_SolConexionAutogen");
        }
    }
}
