namespace Infrastructure.Data.Configurations.Oracle
{
    using Core.Entities.Oracle;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    internal class Creg075ReciboTecnicoConfiguration : IEntityTypeConfiguration<Creg075ReciboTecnico>
    {
        public void Configure(EntityTypeBuilder<Creg075ReciboTecnico> entity)
        {
            entity.ToTable("CREG_075_RECIBO_TECNICO");

            entity.Property(e => e.Id)
                .HasPrecision(10)
                .ValueGeneratedNever()
                .HasColumnName("ID");

            entity.Property(e => e.CedulaIngeniero)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CEDULA_INGENIERO");

            entity.Property(e => e.CedulaPropietario)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("CEDULA_PROPIETARIO");

            entity.Property(e => e.ClienteCargoMedidor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CLIENTE_CARGO_MEDIDOR");

            entity.Property(e => e.Cod075Conexion)
                .HasPrecision(10)
                .HasColumnName("COD_075_CONEXION");

            entity.Property(e => e.CodComercializador)
                .HasColumnType("NUMBER")
                .HasColumnName("COD_COMERCIALIZADOR");

            entity.Property(e => e.CodPersonaAutorizacion)
                .HasPrecision(10)
                .HasColumnName("COD_PERSONA_AUTORIZACION");

            entity.Property(e => e.CodTipoCompletitud)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_COMPLETITUD");

            entity.Property(e => e.CodTipoSolicitud)
                .HasPrecision(10)
                .HasColumnName("COD_TIPO_SOLICITUD");

            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DIRECCION");

            entity.Property(e => e.EmailIngeniero)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EMAIL_INGENIERO");

            entity.Property(e => e.EmailPropietario)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("EMAIL_PROPIETARIO");

            entity.Property(e => e.Estado)
                .HasPrecision(1)
                .HasColumnName("ESTADO")
                .HasDefaultValueSql("1\n        \n");

            entity.Property(e => e.Etapa)
                .HasPrecision(10)
                .HasColumnName("ETAPA")
                .HasDefaultValueSql("1 ");

            entity.Property(e => e.EtapaProyecto)
                .HasPrecision(10)
                .HasColumnName("ETAPA_PROYECTO")
                .HasDefaultValueSql("1");

            entity.Property(e => e.FechaSolicitud)
                .HasColumnType("DATE")
                .HasColumnName("FECHA_SOLICITUD");

            entity.Property(e => e.FirmaIngeniero)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("FIRMA_INGENIERO");

            entity.Property(e => e.FirmaPropietario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("FIRMA_PROPIETARIO");

            entity.Property(e => e.MatriculaProfesional)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MATRICULA_PROFESIONAL");

            entity.Property(e => e.NitConstructora)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NIT_CONSTRUCTORA");

            entity.Property(e => e.NombreConstructora)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_CONSTRUCTORA");

            entity.Property(e => e.NombreIngeniero)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_INGENIERO");

            entity.Property(e => e.NombrePropietario)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PROPIETARIO");

            entity.Property(e => e.NombreProyecto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PROYECTO");

            entity.Property(e => e.NumeroMatricula)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("NUMERO_MATRICULA");

            entity.Property(e => e.Observaciones)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("OBSERVACIONES");

            entity.Property(e => e.OficinaRadicacion)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("OFICINA_RADICACION");

            entity.Property(e => e.TelefonoIngeniero)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_INGENIERO");

            entity.Property(e => e.TelefonoPropietario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TELEFONO_PROPIETARIO");

            entity.HasOne(d => d.CodPersonaAutorizacion)
                .WithMany(p => p.Creg075ReciboTecnico)
                .HasForeignKey(d => d.CodPersonaAutorizacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionReciboTecnico_PersonaAutorizaRecibo");

            entity.HasOne(d => d.Cod075Conexion)
                .WithMany(p => p.Creg075ReciboTecnicos)
                .HasForeignKey(d => d.Cod075Conexion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionReciboTecnico_SolServicioConexion");

            entity.HasOne(d => d.CodTipoCompletitud)
                .WithMany(p => p.Creg075ReciboTecnico)
                .HasForeignKey(d => d.CodTipoCompletitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionReciboTecnico_TipoCompletitud");

            entity.HasOne(d => d.CodTipoSolicitud)
                .WithMany(p => p.Creg075ReciboTecnico)
                .HasForeignKey(d => d.CodTipoSolicitud)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SolServicioConexionReciboTecnico_TipoSolicitud");
        }
    }
}
