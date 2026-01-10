using AngleSharp.Dom;
using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class TipoEtapaConfiguration : IEntityTypeConfiguration<TipoEtapa>
    {
        public void Configure(EntityTypeBuilder<TipoEtapa> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("TipoEtapa", "par");

            entity.Property(e => e.Id)
                    .HasColumnName("IdTipoEtapa")
                    .ValueGeneratedNever();

            entity.Property(e => e.CodUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7|7|7')");

            entity.Property(e => e.CodUserUpdate)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7|7|7')");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Descripción del tipo de etapa");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("Estado del registro");

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
        }
    }
}
