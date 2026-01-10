using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolConexionAutogenInmuebleConfiguration : IEntityTypeConfiguration<SolConexionAutogenInmueble>
    {
        public void Configure(EntityTypeBuilder<SolConexionAutogenInmueble> entity)
        {
            entity.HasKey(e => e.CodSolConexionAutogen)
                    .HasName("PK__tmp_ms_x__7570AF2D55CF65BD");

            entity.ToTable("SolConexionAutogenInmueble", "sol");

            entity.Property(e => e.CodSolConexionAutogen)
                .ValueGeneratedNever()
                .HasComment("Codigo maestro de Solicitud de Conexion");

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

            entity.Property(e => e.Corregimiento)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Corregimiento del proyecto");

            entity.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Direccion de ubicacion del proyecto");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.IdSolConexionAutogenInmueble).ValueGeneratedOnAdd();

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

            entity.Property(e => e.Municipio).HasComment("Municipio del proyecto");

            entity.Property(e => e.NumeroPosteTransformador)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Codigo de matricula del poste o transformador mas cercano");

            entity.Property(e => e.UbicacionGeoWgs)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("UbicacionGeoWGS")
                .HasComment("Ubicacion georreferenciada wgs84 (de googlemaps)");

            entity.Property(e => e.Vereda)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Vereda del proyecto");

            entity.HasOne(d => d.MunicipioNavigation)
                .WithMany(p => p.SolConexionAutogenInmuebles)
                .HasForeignKey(d => d.Municipio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolConexionAutogenInmueble_Municipio");
        }
    }
}
