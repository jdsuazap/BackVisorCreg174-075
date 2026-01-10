using Core.Entities.SQLContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.SQLContext
{
    public class SolServicioConexionConfiguration : IEntityTypeConfiguration<SolServicioConexion>
    {
        public void Configure(EntityTypeBuilder<SolServicioConexion> entity)
        {
            entity.HasKey(e => e.Id)
                    .HasName("PK_SolicitudConexionFactibilidad");

            entity.ToTable("SolServicioConexion", "sol");

            entity.Property(e => e.Id)
                .HasComment("Identificación del registro")
                .HasColumnName("IdSolServicioConexion");

            entity.Property(e => e.CodActividadEconomica).HasComment("ID Actividad económica industrial CIIU");

            entity.Property(e => e.CodEstado).HasComment("Estado actual de la solicitud");

            entity.Property(e => e.CodEstrato).HasComment("ID del Estrato socioeconómico");

            entity.Property(e => e.CodTipoConexion).HasComment("Id del tipo de conexión asociados a esta solicitud");

            entity.Property(e => e.CodTipoUso).HasComment("Id del tipo de uso ");

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

            entity.Property(e => e.CodUsuario).HasComment("Codigo maestro de usuario (cliente)");

            entity.Property(e => e.DistanciaRedCercana)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasComment(" Distancia actual del predio a la red más cercana");

            entity.Property(e => e.ExisteRedCercana).HasComment("¿Hay red eléctrica cercana al predio? (0-no, 1-si)");

            entity.Property(e => e.FechaRegistro)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de creación del registro.");

            entity.Property(e => e.FechaRegistroUpdate)
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())")
                .HasComment("Fecha de la ultima actualización del registro.");

            entity.Property(e => e.FechaSolicitud)
                .HasColumnType("datetime")
                .HasComment("Fecha en la que se realizo la solicitud");

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

            entity.Property(e => e.Transformador)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment(" Número de transformador de la red eléctrica más cercano");

            entity.Property(e => e.Nodo)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment(" Número de poste de la red eléctrica más cercano");

            entity.Property(e => e.Circuito)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasComment(" Circuito de la red eléctrica más cercano");

            entity.Property(e => e.NumeroRadicado)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasComment("Numero del radicado generado para la solicitud");

            entity.Property(e => e.ObservacionesSolicitante)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasComment("Observaciones del solicitante");

            entity.Property(e => e.OtroTipoUso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasComment("Nombre del tipo de uso si el usuario selecciono la opción de tipo de uso \"Otro\"");           

            entity.Property(e => e.SeguimientoDocumentacionCompleta)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("En este campo se confirma si la documentacion esta completa o no");

            entity.Property(e => e.SeguimientoObraConforme)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("En este campo se confirma si la documentacion esta conforme o no.\n");

            entity.Property(e => e.ReciboTecnicoDocumentacionCompleta)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("En este campo se confirma si la documentacion esta completa o no");

            entity.Property(e => e.NormalizacionVisitaConforme)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("En este campo se confirma si la documentacion esta conforme o no");            
            
            entity.Property(e => e.PuedeActualizarFactibilidadPerfilApoyo)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("En este campo es para verificar si puede actualizar la factibilidad el oerfil de apoyo.");

            entity.Property(e => e.DesistirSolicitudHabilitado)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("En este campo es para indicar que el usuario quiere desistir de una solicitud.");

            entity.Property(e => e.NormalizacionOtraEtapa)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("En este campo se confirma si la documentacion requeire otra etapa o no");

            entity.Property(e => e.AnulacionHabilitada)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("En este campo se confirma si la documentacion requeire otra etapa o no");         
            
            entity.Property(e => e.PuedeRealizarFactibilidad)
                .IsRequired()
                .HasDefaultValue(false)
                .HasComment("En este campo se confirma si puede realizar factibilidad");

            entity.Property(e => e.Etapa)
                .HasDefaultValueSql("((1))");
        }
    }
}
