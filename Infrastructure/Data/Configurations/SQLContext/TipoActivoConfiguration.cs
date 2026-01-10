using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class TipoActivoConfiguration : IEntityTypeConfiguration<TipoActivo>
    {
        public void Configure(EntityTypeBuilder<TipoActivo> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__TipoActi__10ABF1158F2B62E5");

            entity.ToTable("TipoActivo", "par");

            entity.Property(e => e.Id)
                .HasMaxLength(200)
                .HasColumnName("IdTipoActivo")
                .IsUnicode(false);

            entity.Property(e => e.AltoIconoMapa)
                .HasDefaultValueSql("((0))")
                .HasComment("Tamaño del icono (Alto), en el mapa de google");

            entity.Property(e => e.AnchoIconoMapa)
                .HasDefaultValueSql("((0))")
                .HasComment("Tamaño del icono (Ancho), en el mapa de google");

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

            entity.Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Descripcion del registro");

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

            entity.Property(e => e.UrlIconoMapa)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("URL del icono a mostrar en el mapa de google");
        }
    }
}
