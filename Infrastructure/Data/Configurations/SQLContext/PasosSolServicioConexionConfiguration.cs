using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class PasosSolServicioConexionConfiguration : IEntityTypeConfiguration<PasosSolServicioConexion>
    {
        public void Configure(EntityTypeBuilder<PasosSolServicioConexion> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__PasosSol__0DDD221F979747FF");

            entity.ToTable("PasosSolServicioConexion", "sol");

            entity.Property(e => e.Id)
                .HasColumnName("IdPasosSolServicioConexion")
                .HasComment("Id registro");

            entity.Property(e => e.Etapa)
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.CodEstado).HasComment("Codigo maestro de Estado de Solicitud de Conexion");

            entity.Property(e => e.CodSolServicioConexion).HasComment("Codigo maestro de Solicitud de Conexion");

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

            entity.HasOne(d => d.CodSolServicioConexionNavigation)
                .WithMany(p => p.PasosSolServicioConexions)
                .HasForeignKey(d => d.CodSolServicioConexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PasosSolServicioConexion_SolServicioConexion");
        }
    }
}
