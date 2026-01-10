using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolServicioConexionDetalleConfiguration : IEntityTypeConfiguration<SolServicioConexionDetalle>
    {
        public void Configure(EntityTypeBuilder<SolServicioConexionDetalle> entity)
        {
            entity.HasKey(e => e.CodSolServicioConexion)
                    .HasName("PK_SolicitudServicioConexionDetalleServicio");

            entity.ToTable("SolServicioConexionDetalle", "sol");

            entity.Property(e => e.CodSolServicioConexion)
                .ValueGeneratedNever()
                .HasComment("ID Solicitud Servicio Conexión");

            entity.Property(e => e.CargaExistente)
                .HasColumnType("decimal(12, 2)")
                .HasComment("Carga existente en kVA");

            entity.Property(e => e.CargaMaximaRequerida)
                .HasColumnType("decimal(12, 2)")
                .HasComment(" Carga máxima requerida en kVA");

            entity.Property(e => e.CodNivelTension).HasComment("ID  Nivel de tensión solicitado");

            entity.Property(e => e.CodSolServicioConexion).HasComment("ID Solicitud Servicio Conexión");

            entity.Property(e => e.CodTipoServicioSolicitud).HasComment("ID tipo de servicio solicitado ");

            entity.Property(e => e.CodTipoSolicitud).HasComment("ID Tipo de Solicitud");

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
                .HasComment("Cedula del ultimo último que actualizó el registro");

            entity.Property(e => e.FechaEstimadaEntradaOperacion)
                .HasColumnType("datetime")
                .HasComment("Fecha estimada de entrada en operación");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.IdSolServicioConexionDetalle)
                .ValueGeneratedOnAdd()
                .HasComment("Identificación del registro");

            entity.Property(e => e.IncluyeSistemaGeneracion).HasComment("Si el proyecto incluye algún sistema de generación (1-Si, 0-No)");

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

            entity.Property(e => e.NombreProyecto)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("No,bre del Prooyecto");

            entity.Property(e => e.NumeroSolicitud)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Numero de la solicitud existente a modificar o revaluar");

            entity.Property(e => e.OtroTipoServicioSolicitud)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre del tipo servicio de la solicitud que no aparece en el sistema");

            entity.Property(e => e.Vigencia)
                .HasColumnType("datetime")
                .HasComment("Fecha Vigencia solicitud existente");           

            entity.HasOne(d => d.CodSolServicioConexionNavigation)
                .WithOne(p => p.SolServicioConexionDetalle)
                .HasForeignKey<SolServicioConexionDetalle>(d => d.CodSolServicioConexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolicitudServicioConexionDetalleServicio_SolicitudServicioConexion");          
        }
    }
}
