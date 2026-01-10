using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class DocumentosXformularioConfiguration : IEntityTypeConfiguration<DocumentosXformulario>
    {
        public void Configure(EntityTypeBuilder<DocumentosXformulario> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK__Document__7EB22C1D416C4D82");

            entity.ToTable("DocumentosXFormulario", "par");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("IdDocumentosXFormulario")
                .HasComment("Identificación del registro");

            entity.Property(e => e.CodFormularioPrincipal).HasComment("Codigo modulo documento");

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
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("Descripcion a mostrar como texto informativo");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("Indica el estado del registro");

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

            entity.Property(e => e.IsCampo)
                .IsRequired()
                .HasDefaultValueSql("((1))")
                .HasComment("Indica si el docuemento hace parte de un campo del formulario");

            entity.Property(e => e.LimitLoad)
                .HasColumnName("limitLoad")
                .HasComment("Indica si este documento tiene limite de cargas");

            entity.Property(e => e.NombreDocumento)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("Descripción del registro");

            entity.Property(e => e.Requiered)
                .HasColumnName("requiered")
                .HasComment("Indica si el documento es requerido");

            entity.Property(e => e.Vigencia).HasComment("Indica si el documento tiene vigencia");

            entity.Property(e => e.VigenciaMaxima).HasComment("Indica vigencia maxima, en dias");
        }
    }
}
