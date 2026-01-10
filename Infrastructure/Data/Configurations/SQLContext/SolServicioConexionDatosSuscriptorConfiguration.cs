using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolServicioConexionDatosSuscriptorConfiguration : IEntityTypeConfiguration<SolServicioConexionDatosSuscriptor>
    {
        public void Configure(EntityTypeBuilder<SolServicioConexionDatosSuscriptor> entity)
        {
            entity.HasKey(e => e.CodSolServicioConexion)
                    .HasName("PK__tmp_ms_x__54EDE146877486F9");

            entity.ToTable("SolServicioConexionDatosSuscriptor", "sol");

            entity.Property(e => e.CodSolServicioConexion)
                .ValueGeneratedNever()
                .HasComment("ID de la solicitud servicio conexion");

            entity.Property(e => e.AutorizacionNotificacionEmail).HasComment("Se valida si el Solicitante o Suscriptor/Usuario autorizo las notificaciones al email");

            entity.Property(e => e.Celular)
                .HasColumnType("numeric(10, 0)")
                .HasComment("Celular del Solicitante o Suscriptor/Usuario");

            entity.Property(e => e.CodDepartamento)
                    .HasMaxLength(10)
                    .IsUnicode(false);

            entity.Property(e => e.CodMunicipio)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasComment("ID del municipio");

            entity.Property(e => e.CodSolServicioConexion).HasComment("ID de la solicitud servicio conexion");

            entity.Property(e => e.CodTipoDocumento).HasComment("ID tipo de documento");

            entity.Property(e => e.CodTipoPersona).HasComment("ID del tipo de persona");

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

            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Dirección del Solicitante o Suscriptor/Usuario");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Email del Solicitante o Suscriptor/Usuario");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.IdSolServicioConexionDatosSuscriptor)
                .ValueGeneratedOnAdd()
                .HasComment("Identificación del registro");

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

            entity.Property(e => e.Nombre)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Nombre del Solicitante o Suscriptor/Usuario");

            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("Documento del Solicitante o Suscriptor/Usuario");

            entity.Property(e => e.Telefono)
                .HasColumnType("numeric(10, 0)")
                .HasComment("Telefono del Solicitante o Suscriptor/Usuario");

            entity.HasOne(d => d.CodSolServicioConexionNavigation)
                .WithOne(p => p.SolServicioConexionDatosSuscriptor)
                .HasForeignKey<SolServicioConexionDatosSuscriptor>(d => d.CodSolServicioConexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionDatosSuscriptor_SolicitudServicioConexion");

            entity.HasOne(d => d.CodDepartamentoNavigation)
                .WithMany(p => p.SolServicioConexionDatosSuscriptors)
                .HasForeignKey(d => d.CodDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionDatosSuscriptor_Departamento");

            entity.HasOne(d => d.CodMunicipioNavigation)
                .WithMany(p => p.SolServicioConexionDatosSuscriptors)
                .HasForeignKey(d => d.CodMunicipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionDatosSuscriptor_Ciudad");
        }
    }
}
