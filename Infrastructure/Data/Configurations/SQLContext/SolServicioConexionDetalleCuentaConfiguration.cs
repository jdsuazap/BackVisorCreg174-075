using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolServicioConexionDetalleCuentaConfiguration : IEntityTypeConfiguration<SolServicioConexionDetalleCuenta>
    {
        public void Configure(EntityTypeBuilder<SolServicioConexionDetalleCuenta> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK_SolicitudServicioConexionDetalleServicioNumeroCuentas");

            entity.ToTable("SolServicioConexionDetalleCuentas", "sol");

            entity.Property(e => e.Id)
                .HasColumnName("IdSolServicioConexionDetalleCuentas")
                .HasComment("Identificación del registro");

            entity.Property(e => e.CodSolServicioConexion).HasComment("ID Solicitud Servicio Conexión");

            entity.Property(e => e.CodTipoCarga).HasComment("ID Tipo Carga");

            entity.Property(e => e.CodTipoClaseCarga).HasComment("ID Tipo Clase Carga");

            entity.Property(e => e.CodUser)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cedula del último que crea el registro");

            entity.Property(e => e.CodUserUpdate)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cedula del último que actualizó el registro");

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
                .HasComment("En este campo almacenamos la dirección ip, navegador y versión del navegador del cliente.");

            entity.Property(e => e.InfoUpdate)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la ultima dirección ip, navegador y versión del navegador del cliente.");

            entity.Property(e => e.ValorCarga)
                .HasColumnType("decimal(12, 2)")
                .HasComment("Valor de la carga");

            entity.HasOne(d => d.CodSolServicioConexionNavigation)
                .WithMany(p => p.SolServicioConexionDetalleCuenta)
                .HasForeignKey(d => d.CodSolServicioConexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionDetalleCuentas_SolServicioConexion");           
        }
    }
}
