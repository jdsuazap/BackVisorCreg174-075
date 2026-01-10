using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolConexionAutogenNoBasadaInvConfiguration : IEntityTypeConfiguration<SolConexionAutogenNoBasadaInv>
    {
        public void Configure(EntityTypeBuilder<SolConexionAutogenNoBasadaInv> entity)
        {
            entity.HasKey(e => e.CodSolConexionAutogen)
                    .HasName("PK__tmp_ms_x__7570AF2D8CD6D477");

            entity.ToTable("SolConexionAutogenNoBasadaInv", "sol");

            entity.Property(e => e.CodSolConexionAutogen)
                .ValueGeneratedNever()
                .HasComment("Codigo maestro de Solicitud de Conexion");

            entity.Property(e => e.AnioIeee1547)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("AnioIEEE1547")
                .HasComment("Version (año) [estandar IEEE 1547-2003 o superior]");

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

            entity.Property(e => e.CumpleIeee1547)
                .HasColumnName("CumpleIEEE1547")
                .HasComment("Cumple estandar IEEE 1547-2003 o superior");

            entity.Property(e => e.DescripcionElementos)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("Elementos de proteccion, control o maniobra que limitan la inyeccion de energia a la red");

            entity.Property(e => e.FabricanteGenerador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Fabricante del Generador");

            entity.Property(e => e.FactorPotencia)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Factor de potencia");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.IdSolConexionAutogenNoBasadaInv).ValueGeneratedOnAdd();

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

            entity.Property(e => e.ModeloGenerador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Modelo del generador");

            entity.Property(e => e.NumeroFases)
                .HasColumnType("numeric(6, 0)")
                .HasComment("Numero de fases");

            entity.Property(e => e.PotenciaNominal)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Potencia nominal (kVA) del generador");

            entity.Property(e => e.TransfoGrupoConex)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("Transfo_GrupoConex")
                .HasComment("Grupo de conexion");

            entity.Property(e => e.TransfoImpedanciaCc)
                .HasColumnType("numeric(10, 4)")
                .HasColumnName("Transfo_ImpedanciaCC")
                .HasComment("Impedancia de C.C. (%)");

            entity.Property(e => e.TransfoPotNominal)
                .HasColumnType("numeric(10, 4)")
                .HasColumnName("Transfo_PotNominal")
                .HasComment("Potencia nominal (kVA) del transformador");

            entity.Property(e => e.VoltajeGenerador)
                .HasColumnType("numeric(6, 0)")
                .HasComment("Voltaje del generador (V)");
        }
    }
}
