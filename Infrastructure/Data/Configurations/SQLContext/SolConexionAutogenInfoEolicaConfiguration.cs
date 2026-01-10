using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolConexionAutogenInfoEolicaConfiguration : IEntityTypeConfiguration<SolConexionAutogenInfoEolica>
    {
        public void Configure(EntityTypeBuilder<SolConexionAutogenInfoEolica> entity)
        {
            entity.HasKey(e => e.CodSolConexionAutogen)
                    .HasName("PK__tmp_ms_x__7570AF2DC9F6C10C");

            entity.ToTable("SolConexionAutogenInfoEolica", "sol");

            entity.Property(e => e.CodSolConexionAutogen)
                .ValueGeneratedNever()
                .HasComment("Codigo maestro de Solicitud de Conexion");

            entity.Property(e => e.AnioIeee1547)
                .HasColumnType("numeric(4, 0)")
                .HasColumnName("AnioIEEE1547")
                .HasComment("Version (año) [estandar IEEE 1547-2003 o superior]");

            entity.Property(e => e.CodTipoAerogenerador).HasComment("Codigo maestro de Tipo Aerogenerador");

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

            entity.Property(e => e.FabricanteAerogenerador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Fabricante del aerogenerador");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.IdSolConexionAutogenInfoEolica).ValueGeneratedOnAdd();

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

            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Modelo");

            entity.Property(e => e.NumAerogeneradores)
                .HasColumnType("numeric(6, 0)")
                .HasComment("Numero de aerogeneradores");

            entity.Property(e => e.PoseePpc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PoseePPC")
                .HasComment("Cuenta con control central de planta (PPC)");

            entity.Property(e => e.PotenciaNominal)
                .HasColumnType("numeric(10, 4)")
                .HasComment("Potencia nominal (kW)");

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

            entity.Property(e => e.VoltajeAc)
                .HasColumnType("numeric(10, 4)")
                .HasColumnName("VoltajeAC")
                .HasComment("Voltaje AC  (V)");

            entity.HasOne(d => d.CodTipoAerogeneradorNavigation)
                .WithMany(p => p.SolConexionAutogenInfoEolicas)
                .HasForeignKey(d => d.CodTipoAerogenerador)
                .HasConstraintName("FK_SolConexionAutogenInfoEolica_TipoAerogenerador");
        }
    }
}
