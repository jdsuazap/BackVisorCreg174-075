using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolConexionAutogenAnexoConfiguration : IEntityTypeConfiguration<SolConexionAutogenAnexo>
    {
        public void Configure(EntityTypeBuilder<SolConexionAutogenAnexo> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__SolConex__9663E2EC598F76BB");

            entity.ToTable("SolConexionAutogenAnexos", "sol");

            entity.Property(e => e.Id)
                .HasColumnName("IdSolConexionAutogenAnexos")
                .HasComment("Identificación del registro");

            entity.Property(e => e.CodDocumentosXformulario)
                .HasColumnName("CodDocumentosXFormulario")
                .HasComment("id del documento a relacionar");

            entity.Property(e => e.CodSolConexionAutogen).HasComment("Id de la tabla a relacionar");

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

            entity.Property(e => e.EstadoDocumento)
                .HasDefaultValueSql("((1))")
                .HasComment("Estado del documento");

            entity.Property(e => e.Expedicion)
                .HasColumnType("datetime")
                .HasComment("Fecha de vencimiento del documento, si aplica");

            entity.Property(e => e.ExtDocument)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasComment("Extensión del documento");

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

            entity.Property(e => e.NameDocument)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nombre del documento");

            entity.Property(e => e.OriginalNameDocument)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nombre original del documento");

            entity.Property(e => e.SendNotification).HasComment("Este campo indica si ya ha sido envio correo electronico con la notificacion del cambio");

            entity.Property(e => e.SizeDocument).HasComment("tamaño del documento");

            entity.Property(e => e.UrlDocument)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("Ruta del documento");

            entity.Property(e => e.UrlRelDocument)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("Ruta relativa del documento");

            entity.Property(e => e.ValidationDocument).HasComment("Este campo indica si el documento ha sido validado por el gestor de documentos al ser cargado por el proveedor");

            entity.HasOne(d => d.CodSolConexionAutogenNavigation)
                .WithMany(p => p.SolConexionAutogenAnexos)
                .HasForeignKey(d => d.CodSolConexionAutogen)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolConexionAutogenAnexos_SolConexionAutogen");
        }
    }
}
