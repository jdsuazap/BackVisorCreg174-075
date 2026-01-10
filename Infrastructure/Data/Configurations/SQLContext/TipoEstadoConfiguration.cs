using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    internal class TipoEstadoConfiguration : IEntityTypeConfiguration<TipoEstado>
    {
        public void Configure(EntityTypeBuilder<TipoEstado> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("TipoEstado", "par");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("teIdEstado")
                .HasComment("Identificación del registro");

            entity.Property(e => e.CodUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7|7|7')");

            entity.Property(e => e.CodUserUpdate)
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
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')");

            entity.Property(e => e.InfoUpdate)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')");

            entity.Property(e => e.TeDescripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("teDescripcion")
                .HasComment("Descripción del estado");

            entity.Property(e => e.TeEstado)
                .IsRequired()
                .HasColumnName("teEstado")
                .HasDefaultValueSql("((1))")
                .HasComment("Estado del registro");
        }
    }
}
