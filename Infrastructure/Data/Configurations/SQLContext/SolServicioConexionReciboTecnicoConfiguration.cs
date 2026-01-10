using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolServicioConexionReciboTecnicoConfiguration : IEntityTypeConfiguration<SolServicioConexionReciboTecnico>
    {
        public void Configure(EntityTypeBuilder<SolServicioConexionReciboTecnico> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK_SolicitudReciboTecnico");

            entity.ToTable("SolServicioConexionReciboTecnico", "sol");

            entity.Property(e => e.Id)
                  .HasColumnName("IdSolServicioConexionReciboTecnico")
                  .HasComment("Identificación del registro")
                  .ValueGeneratedOnAdd();

            entity.Property(e => e.CedulaIngeniero)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.CedulaPropietario)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.ClienteCargoCobroMedidores)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("No Cliente activo para cargar cobro de medidores");

            entity.Property(e => e.CodPersonaAutorizacion).HasComment("ID Persona autorización recibo");

            entity.Property(e => e.CodSolServicioConexion).HasComment("ID asociado a la solicitud del servicio de conexión");

            entity.Property(e => e.CodTipoCompletitud).HasComment("ID Tipo Completitud");

            entity.Property(e => e.CodUser)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cedula del usuario que crea el registro");

            entity.Property(e => e.CodUserUpdate)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasDefaultValueSql("('7777777')")
                .HasComment("Cedula del último usuario que actualizó el registro");

            entity.Property(e => e.Comercializador)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Comercializador de la obra");

            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Dirección de la obra");

            entity.Property(e => e.EmailIngeniero)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Email del ingeniero");

            entity.Property(e => e.EmailPropietario)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Email del Propietario");

            entity.Property(e => e.Estado)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.Property(e => e.Etapa).HasDefaultValueSql("((1))");

            entity.Property(e => e.EtapaProyecto)
                .HasDefaultValueSql("((1))")
                .HasComment("Etapa del proyecto");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.FechaSolicitud)
                .HasColumnType("datetime")
                .HasComment("Fecha de la solicitud");

            entity.Property(e => e.FirmaIngeniero)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Firma Ingeniero");

            entity.Property(e => e.FirmaPropietario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Firma del Propietario");

            entity.Property(e => e.Info)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la dirección ip, navegador y versión del navegador del cliente.");

            entity.Property(e => e.InfoUpdate)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasDefaultValueSql("('0|0|0')")
                .HasComment("En este campo almacenamos la ultima direccion ip, navegador y version del navegador del cliente.");

            entity.Property(e => e.MatriculaProfesional)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Matricula Profesional del Ingeniero");

            entity.Property(e => e.NitConstructora)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasComment("Nit de la constructora");

            entity.Property(e => e.NombreConstructora)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment("Nombre Constructora");

            entity.Property(e => e.NombreIngeniero)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Nombre del ingeniero");

            entity.Property(e => e.NombrePropietario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasComment("Nombre del Propietario");

            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nombre del proyecto");

            entity.Property(e => e.NumeroMatricula)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasComment("Número de matrícula inmobiliaria");

            entity.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasComment("Observaciones de la solicitud recibo tecnico");

            entity.Property(e => e.OficinaRadicacion)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.TelefonoIngeniero)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.Property(e => e.TelefonoPropietario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasComment("Teléfono del Propietario");

            entity.HasOne(d => d.CodSolServicioConexionNavigation)
                .WithMany(p => p.SolServicioConexionReciboTecnicos)
                .HasForeignKey(d => d.CodSolServicioConexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionReciboTecnico_SolServicioConexion");

            entity.HasOne(d => d.CodTipoCompletitudNavigation)
                .WithMany(p => p.SolServicioConexionReciboTecnicos)
                .HasForeignKey(d => d.CodTipoCompletitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionReciboTecnico_TipoCompletitud");

            entity.HasOne(d => d.CodTipoSolicitudNavigation)
                .WithMany(p => p.SolServicioConexionReciboTecnicos)
                .HasForeignKey(d => d.CodTipoSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionReciboTecnico_TipoSolicitud");
        }
    }
}
