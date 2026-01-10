using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__Ciudad__D4D3CCB027EB85D4");

            entity.ToTable("Ciudad", "par");

            entity.Property(e => e.Id)
                .HasColumnName("IdCiudad")
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasComment("Identificación del registro");

            entity.Property(e => e.CodDepartamento)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasComment("Codigo de la tabla departamento");

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

            entity.Property(e => e.NombreCiudad)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre de la ciudad");

            entity.HasOne(d => d.CodDepartamentoNavigation)
                .WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.CodDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ciudad_Departamento");
        }
    }
}
