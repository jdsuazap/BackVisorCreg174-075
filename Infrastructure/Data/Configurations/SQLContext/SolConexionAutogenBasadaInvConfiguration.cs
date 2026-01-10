using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolConexionAutogenBasadaInvConfiguration : IEntityTypeConfiguration<SolConexionAutogenBasadaInv>
    {
        public void Configure(EntityTypeBuilder<SolConexionAutogenBasadaInv> entity)
        {
            entity.HasKey(e => e.CodSolConexionAutogen)
                    .HasName("PK__tmp_ms_x__7570AF2DEDBA2649");

            entity.ToTable("SolConexionAutogenBasadaInv", "sol");

            entity.Property(e => e.CodSolConexionAutogen)
                .ValueGeneratedNever()
                .HasComment("Codigo maestro de Solicitud de Conexion");

            entity.Property(e => e.AnioIec61727)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("AnioIEC61727")
                .HasComment("Version (año) [estandar IEC 61727-2004 o superior]");

            entity.Property(e => e.AnioUl1741)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("AnioUL1741")
                .HasComment("Version (año) [estandar UL 1741-2010 o superior]");

            entity.Property(e => e.CapacidadDc)
                .HasColumnType("numeric(10, 4)")
                .HasColumnName("CapacidadDC")
                .HasComment("Capacidad en DC (kW DC)");

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

            entity.Property(e => e.CumpleIec61727)
                .HasColumnName("CumpleIEC61727")
                .HasComment("Cumple estandar IEC 61727-2004 o superior");

            entity.Property(e => e.CumpleUl1741)
                .HasColumnName("CumpleUL1741")
                .HasComment("Cumple estandar UL 1741-2010 o superior");

            entity.Property(e => e.DescripcionElementos)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasComment("Elementos de proteccion, control o maniobra que limitan la inyeccion de energia a la red");

            entity.Property(e => e.FabricanteInv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Fabricante de los inversores");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.IdSolConexionAutogenBasadaInv).ValueGeneratedOnAdd();

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

            entity.Property(e => e.ModeloInv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Modelo de los inversores");

            entity.Property(e => e.NumFases)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Numero de fases");

            entity.Property(e => e.NumInversores)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Numero de Inversores");

            entity.Property(e => e.NumPaneles)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Numero de paneles");

            entity.Property(e => e.PoseePpc)
                .HasColumnName("PoseePPC")
                .HasComment("Cuenta con control central de planta (PPC)");

            entity.Property(e => e.PoseeRele).HasComment("Posee rele de flujo inverso");

            entity.Property(e => e.PotTotalAc)
                .HasColumnType("numeric(10, 4)")
                .HasColumnName("PotTotalAC")
                .HasComment("Potencia total en AC (kW AC)");

            entity.Property(e => e.PotenciaPanel)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Potencia por panel");

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
                .HasComment("Potencia nominal (kVA)");

            entity.Property(e => e.VoltEntInv)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Voltaje entrada del Inversor (V)");

            entity.Property(e => e.VoltSalInv)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Voltaje salida del Inversor (V)");
        }
    }
}
