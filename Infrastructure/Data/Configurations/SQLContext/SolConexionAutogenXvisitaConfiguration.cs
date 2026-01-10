using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolConexionAutogenXvisitaConfiguration : IEntityTypeConfiguration<SolConexionAutogenXvisita>
    {
        public void Configure(EntityTypeBuilder<SolConexionAutogenXvisita> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__SolConex__4976A613A7510111");

            entity.ToTable("SolConexionAutogenXVisita", "sol");

            entity.Property(e => e.Id)
                .HasColumnName("IdSolConexionAutogenXVisita");

            entity.Property(e => e.CodSolConexionAutogen).HasComment("Codigo maestro de Solicitud de Conexion");

            entity.Property(e => e.CodTipoTramiteVisita).HasComment("Codigo maestro de Tipo Tramite Visita");

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

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Email de persona que atiende la visita");

            entity.Property(e => e.EquiposCumplen).HasComment("Si entrega excedentes, indica si los equipos de medicion cumplen con lo establecido en el codigo de medida");

            entity.Property(e => e.Estado).HasComment("Codigo maestro de Estado");

            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasComment("Fecha de generacion de Solicitud de Visita");

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

            entity.Property(e => e.NombreAtiendeVisita)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre de la persona que atiende la visita");

            entity.Property(e => e.Observaciones)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("Observaciones de la solicitud de Visita");

            entity.Property(e => e.Telefono)
                .HasColumnType("numeric(10, 0)")
                .HasComment("Telefono de persona que atiende la visita");
        }
    }
}
