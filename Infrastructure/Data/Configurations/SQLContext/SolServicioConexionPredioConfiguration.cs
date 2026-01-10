using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolServicioConexionPredioConfiguration : IEntityTypeConfiguration<SolServicioConexionPredio>
    {
        public void Configure(EntityTypeBuilder<SolServicioConexionPredio> entity)
        {
            entity.HasKey(e => e.CodSolServicioConexion);

            entity.ToTable("SolServicioConexionPredio", "sol");

            entity.Property(e => e.CodSolServicioConexion)
                .ValueGeneratedNever()
                .HasComment("ID Solicitud Conexión Factibilidad");

            entity.Property(e => e.CodDepartamento)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("ID del Departamento");

            entity.Property(e => e.CodMunicipio)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasComment("ID Municipio donde se encuentra el predio");

            entity.Property(e => e.CodTipoConstruccion).HasComment("Codigo maestro de TipoConstruccion");

            entity.Property(e => e.CodTipoZona).HasComment("Zona en la que se encuentra el predio (1-Urbana, 2-Rural)");

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

            entity.Property(e => e.DescripcionAccesoPredio)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("Indicaciones de acceso al predio");

            entity.Property(e => e.DireccionPredio)
                .IsRequired()
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Dirección del predio");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.IdSolServicioConexionPredio)
                .ValueGeneratedOnAdd()
                .HasComment("Identificación del registro");

            entity.Property(e => e.IdentificacionCliente)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("Número de Identificación del Cliente - NIU");

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

            entity.Property(e => e.Localidad)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Localidad donde se encuentra el predio");

            entity.Property(e => e.MatriculaInmobiliaria)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasComment("Matricula Inmobiliaria de la edificación existente");

            entity.Property(e => e.UbicacionH)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("H Ubicación georreferenciada WGS 84 ");

            entity.Property(e => e.UbicacionLat)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("Latitud  Ubicación georreferenciada WGS 84 ");

            entity.Property(e => e.UbicacionLong)
                .IsRequired()
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("Longitud Ubicación georreferenciada WGS 84 ");

            entity.HasOne(d => d.CodSolServicioConexionNavigation)
                .WithOne(p => p.SolServicioConexionPredio)
                .HasForeignKey<SolServicioConexionPredio>(d => d.CodSolServicioConexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionPredio_SolServicioConexion");           
        }
    }
}
