using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolServicioConexionDisenioConfiguration : IEntityTypeConfiguration<SolServicioConexionDisenio>
    {
        public void Configure(EntityTypeBuilder<SolServicioConexionDisenio> entity)
        {
            entity.HasKey(e => e.Id);

            entity.ToTable("SolServicioConexionDisenio", "sol");

            entity.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .HasComment("Id del diseño de servicio de conexión");

            entity.Property(e => e.CodServicioConexion)
                .HasColumnName("CodServicioConexion")
                .IsRequired()
                .HasComment("Código del servicio de conexión asociado al diseño");

            entity.Property(e => e.CodFactibilidad)
                .HasColumnName("CodFactibilidad")
                .IsRequired()
                .HasComment("Código de la factibilidad asociada al diseño");

            entity.Property(e => e.TipoDocumento)
                .HasColumnName("TipoDocumento")
                .IsRequired()
                .HasComment("Tipo de documento asociado al diseño");

            entity.Property(e => e.NombreProyecto)
                .HasColumnName("NombreProyecto")
                .HasMaxLength(50)
                .IsRequired()
                .HasComment("Nombre del proyecto asociado al diseño");

            entity.Property(e => e.NombreConstructora)
                .HasColumnName("NombreConstructora")
                .HasMaxLength(100)
                .HasComment("Nombre de la constructora asociada al diseño");

            entity.Property(e => e.Nit)
                .HasColumnName("Nit")
                .HasMaxLength(50)
                .HasComment("Número de Identificación Tributaria (NIT) asociado al diseño");

            entity.Property(e => e.TieneDocumentacion)
                .IsRequired()
                .HasDefaultValue(true)
                .HasComment("Estado indica si la documentacion esta completa");
            entity.Property(e => e.Etapa);

            entity.Property(e => e.CedulaObservaciones)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('')");

            entity.Property(e => e.NombreObservaciones)
                    .HasMaxLength(500)
                    .HasDefaultValueSql("('')");

            entity.Property(e => e.Etapa);

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValue(true)
                .HasComment("Estado del diseño");

            entity.Property(e => e.CodUser)
                .HasColumnName("CodUser")
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cédula del usuario que crea el registro");

            entity.Property(e => e.FechaRegistro)
                .HasColumnName("FechaRegistro")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro");

            entity.Property(e => e.CodUserUpdate)
                .HasColumnName("CodUserUpdate")
                .HasMaxLength(30)
                .IsRequired()
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cédula del último usuario que actualizó el registro");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnName("FechaRegistroUpdate")
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la última actualización del registro");

            entity.Property(e => e.Info)
                .HasColumnName("Info")
                .HasMaxLength(200)
                .IsRequired()
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la dirección IP, navegador y versión del navegador del cliente.");

            entity.Property(e => e.InfoUpdate)
                .HasColumnName("InfoUpdate")
                .HasMaxLength(200)
                .IsRequired()
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la última dirección IP, navegador y versión del navegador del cliente.");

            // Definir la relación con SolServicioConexion
            entity.HasOne(d => d.SolServicioConexion)
                .WithMany(p => p.SolServicioConexionDisenio)
                .HasForeignKey(d => d.CodServicioConexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServicioConexion_SolServicioConexionDiseñ");

            // Definir la relación con SolServicioConexionFactibilidades
            entity.HasOne(d => d.SolServicioConexionFactibilidad)
                .WithMany(p => p.SolServicioConexionDisenios)
                .HasForeignKey(d => d.CodFactibilidad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Diseño_Factibilidad");
        }
    }
}
