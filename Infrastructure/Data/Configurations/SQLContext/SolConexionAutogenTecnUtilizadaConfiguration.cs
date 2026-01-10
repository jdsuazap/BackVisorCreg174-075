using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolConexionAutogenTecnUtilizadaConfiguration : IEntityTypeConfiguration<SolConexionAutogenTecnUtilizada>
    {
        public void Configure(EntityTypeBuilder<SolConexionAutogenTecnUtilizada> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__tmp_ms_x__C0AD9951A8BF0E3C");

            entity.ToTable("SolConexionAutogenTecnUtilizadas", "sol");

            entity.Property(e => e.Id).HasColumnName("IdSolConexionAutogenTecnUtilizadas");

            entity.Property(e => e.CapacidadKwPorTecnologia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Descripcion de capacidad en kW por cada tecnologia utilizada");

            entity.Property(e => e.CodSolConexionAutogen).HasComment("Codigo maestro de Solicitud de Conexion");

            entity.Property(e => e.CodTipoTecnologia).HasComment("Codigo maestro de Tipo Tecnologia");

            entity.Property(e => e.CodUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cedula del usuario que crea el registro");

            entity.Property(e => e.CodUserUpdate)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cedula del ultimo usuario que actualizó el registro");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.Info)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la direccion ip, navegador y version del navegador del cliente.");

            entity.Property(e => e.InfoUpdate)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la ultima direccion ip, navegador y version del navegador del cliente.");

            entity.Property(e => e.OtroTipoTecnologia)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Otro tipo de tecnologia utilizada");

            entity.HasOne(d => d.CodSolConexionAutogenNavigation)
                .WithMany(p => p.SolConexionAutogenTecnUtilizada)
                .HasForeignKey(d => d.CodSolConexionAutogen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolConexionAutogenTecnUtilizadas_SolConexionAutogen");

            entity.HasOne(d => d.CodTipoTecnologiaNavigation)
                .WithMany(p => p.SolConexionAutogenTecnUtilizada)
                .HasForeignKey(d => d.CodTipoTecnologia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolConexionAutogenTecnUtilizadas_TipoTecnologia");
        }
    }
}
