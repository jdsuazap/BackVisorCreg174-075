using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolConexionAutogenComentarioConfiguration : IEntityTypeConfiguration<SolConexionAutogenComentario>
    {
        public void Configure(EntityTypeBuilder<SolConexionAutogenComentario> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__SolConex__E2568D6A1C40E04F");

            entity.ToTable("SolConexionAutogenComentario", "sol");

            entity.Property(e => e.Id)
                .HasColumnName("IdSolConexionAutogenComentario");

            entity.Property(e => e.CodEstadoSolicitud).HasComment("Codigo maestro de Estado. Indica el estado actual de la solicitud al momento de realizar el comentario");

            entity.Property(e => e.CodPerfil).HasComment("Codigo maestro de Perfil. Hace referencia al perfil al que se le esta haciendo un comentario");

            entity.Property(e => e.CodSolConexionAutogen).HasComment("Codigo maestro de SolConexionAutogen");

            entity.Property(e => e.CodSolConexionAutogenComentario).HasComment("Codigo padre al que pertenece este comentario, si es null, indica que es comentario padre de lo contrario es una respuesta a un comentario");

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

            entity.Property(e => e.CodUsuario).HasComment("Codigo maestro de Usuario que genera el comentario o respuesta");

            entity.Property(e => e.DescripcionComentario)
                .HasMaxLength(2000)
                .IsUnicode(false)
                .HasComment("Descripcion del comentario realizado");

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
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la direccion ip, navegador y version del navegador del cliente.");

            entity.Property(e => e.InfoUpdate)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la ultima direccion ip, navegador y version del navegador del cliente.");

            entity.Property(e => e.IsGestor).HasComment("Indica si el usuario es Gestor Administrativo de la aplicacion");

            entity.Property(e => e.IsPrivate).HasComment("Indica si el comentario es privado. Solo puede ser visto por los actores implicados");

            entity.Property(e => e.TituloComentario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Titulo para comentario");

            entity.HasOne(d => d.CodEstadoSolicitudNavigation)
                .WithMany(p => p.SolConexionAutogenComentarios)
                .HasForeignKey(d => d.CodEstadoSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolConexionAutogenComentario_Estado");


            entity.HasOne(d => d.CodSolConexionAutogenComentarioNavigation)
                .WithMany(p => p.InverseCodSolConexionAutogenComentarioNavigation)
                .HasForeignKey(d => d.CodSolConexionAutogenComentario)
                .HasConstraintName("FK_SolConexionAutogenComentario_SolConexionAutogenComentario");
        }
    }
}
