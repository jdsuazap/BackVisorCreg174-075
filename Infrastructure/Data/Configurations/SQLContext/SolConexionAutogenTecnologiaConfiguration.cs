using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolConexionAutogenTecnologiaConfiguration : IEntityTypeConfiguration<SolConexionAutogenTecnologia>
    {
        public void Configure(EntityTypeBuilder<SolConexionAutogenTecnologia> entity)
        {
            entity.HasKey(e => e.CodSolConexionAutogen)
                    .HasName("PK__tmp_ms_x__7570AF2D07B3A91D");

            entity.ToTable("SolConexionAutogenTecnologias", "sol");

            entity.Property(e => e.CodSolConexionAutogen)
                .ValueGeneratedNever()
                .HasComment("Codigo maestro de Solicitud de Conexion");

            entity.Property(e => e.AlmacenamientoEnergia).HasComment("Cuenta con almacenamiento de energia");

            entity.Property(e => e.BasadoInversores).HasComment("Sistema basado en inversores");

            entity.Property(e => e.BasadoMaqAsincronicas).HasComment("Sistema basado en maquinas asincronicas");

            entity.Property(e => e.BasadoMaqSincronicas).HasComment("Sistema basado en maquinas sincronicas");

            entity.Property(e => e.CapacidadKw)
                .HasColumnType("numeric(10, 0)")
                .HasComment("Capacidad en kW");

            entity.Property(e => e.CapacidadKwh)
                .HasColumnType("numeric(10, 0)")
                .HasComment("Capacidad en kWh");

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

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.IdSolConexionAutogenTecnologias).ValueGeneratedOnAdd();

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

            entity.Property(e => e.OtraTecnologiaBase)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Otra tecnologia base");
        }
    }
}
