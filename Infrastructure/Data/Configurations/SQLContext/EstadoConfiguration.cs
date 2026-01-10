using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("Estados", "par");

            entity.Property(e => e.Id)
                .HasColumnName("parIdEstado")
                .HasComment("Id registro ")
                .ValueGeneratedNever();

            entity.Property(e => e.CodTipoEstado)
                .HasDefaultValueSql("((1))")
                .HasComment("Indica el tipo de estado al q pertenece, pueden ser proveedores, requerimientos, noticias, ordenes, contratos, entre otros");

            entity.Property(e => e.CodEtapa)
                   .HasComment("Id de la etapa asociada");

            entity.Property(e => e.CodUser)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7|7|7')");

            entity.Property(e => e.CodUserUpdate)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7|7|7')");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            entity.Property(e => e.Info)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')");

            entity.Property(e => e.InfoUpdate)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')");

            entity.Property(e => e.ParDescripcion)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("parDescripcion")
                .HasComment("Descripción del estado");

            entity.Property(e => e.ParvEstado)
                .IsRequired()
                .HasColumnName("parvEstado")
                .HasDefaultValueSql("((1))")
                .HasComment("Estado en q se encuentra el estado, activo - inactivo");

            entity.HasOne(d => d.CodTipoEstadoNavigation)
                .WithMany(p => p.Estados)
                .HasForeignKey(d => d.CodTipoEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Estados_TipoEstado");
        }
    }
}
